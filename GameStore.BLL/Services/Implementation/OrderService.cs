using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.BLL.DTO.Order;
using GameStore.BLL.DTO.OrderDetails;
using GameStore.BLL.Enums;
using GameStore.BLL.Providers;
using GameStore.BLL.Services.Abstract;
using GameStore.BLL.Services.Abstract.Games;
using GameStore.DAL.Context.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.Enums;
using GameStore.DAL.UoW.Abstract;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;


namespace GameStore.BLL.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INorthwindFactory _northwindDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderService> _logger;
        private readonly IGameService _gameService;
        private readonly IMongoLoggerProvider _mongoLogger;

        public OrderService(IGameService gameService,IUnitOfWork unitOfWork, INorthwindFactory northwindDbContext, IMapper mapper, ILogger<OrderService> logger, IMongoLoggerProvider mongoLogger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _northwindDbContext = northwindDbContext;
            _mongoLogger = mongoLogger;
            _gameService = gameService;
        }

        public async Task<OrderDTO> MakeOrderAsync(int orderId)
        {
            Order orderById = await _unitOfWork.OrderRepository.GetAsync(
                o => o.Id == orderId &&
                o.Status != OrderStatus.Processing &&
                o.Status != OrderStatus.Succeeded,
                od => od.OrderDetails);

            if (orderById == null || orderById.OrderDetails == null)
                throw new KeyNotFoundException("Order not found");

            bool isCompletedReserving = await ReserveGamesAsync(orderById.OrderDetails.ToList());

            if (!isCompletedReserving)
                throw new ArgumentException("Order can to be completed");

            _logger.LogInformation($"Games of order with id {orderById.Id} have been reserved");
            orderById.Status = OrderStatus.Processing;
            orderById.OrderDate = DateTime.UtcNow;
            orderById.Expiration = DateTime.UtcNow.AddMinutes(15);
            orderById.ShippedDate = DateTime.UtcNow.AddDays(7);
            Order updatedOrder = await _unitOfWork.OrderRepository.UpdateAsync(orderById, od => od.OrderDetails);
            await _unitOfWork.SaveAsync();

            _logger.LogInformation($"Status of order with id { updatedOrder.Id } has been changed to Processing");

            return _mapper.Map<OrderDTO>(updatedOrder);
        }

        public async Task<OrderDTO> GetOrderAsync(string customerId)
        {
            Order orderByCustomer = await _unitOfWork.OrderRepository.GetAsync(o => o.CustomerId == customerId && o.Status == OrderStatus.Processing, o => o.OrderDetails);

            if (orderByCustomer == null || orderByCustomer.OrderDetails == null)
                throw new KeyNotFoundException("Order not found");

            await GetDetailsByOrderAsync(orderByCustomer);

            return _mapper.Map<OrderDTO>(orderByCustomer);
        }

        public async Task<OrderDTO> GetOrderAsync(int orderId)
        {
            Order orderById = await _unitOfWork.OrderRepository.GetAsync(o => o.Id == orderId, o => o.OrderDetails);

            if (orderById == null || orderById.OrderDetails == null)
                throw new KeyNotFoundException("Order not found");

            await GetDetailsByOrderAsync(orderById);

            return _mapper.Map<OrderDTO>(orderById);
        }

        public async Task<bool> CancelOrderAsync(int orderId)
        {
            Order orderById = await _unitOfWork.OrderRepository.GetAsync(o => o.Id == orderId && o.Status == OrderStatus.Processing, od => od.OrderDetails);
            var oldVersion = orderById.ToBsonDocument();

            if (orderById == null)
                throw new KeyNotFoundException("Order not found");

            await CancelReservedGamesAsync(orderById.OrderDetails.ToList());
            orderById.Status = OrderStatus.Canceled;
            Order canceledOrder = await _unitOfWork.OrderRepository.UpdateAsync(orderById);
            await _unitOfWork.SaveAsync();

            _logger.LogInformation($"Order with id {canceledOrder.Id} has been canceled");
            await _mongoLogger.LogInformation<Order>(ActionType.Update, oldVersion, canceledOrder.ToBsonDocument());

            return true;
        }

        public async Task<List<OrderDTO>> GetStoreOrdersAsync(OrderFilterDTO orderFilterDTO)
        {
            var filter = BuildFilter(orderFilterDTO);
            var storeOrders = await _unitOfWork.OrderRepository.GetRangeAsync(filter, g => g.OrderDetails);
            
            return _mapper.Map<List<OrderDTO>>(storeOrders);
        }

        public async Task<List<OrderDTO>> GetOrderHistoryAsync(OrderFilterDTO orderHistoryDTO)
        {
            List<Order> orders = await FilterOrdersAsync(orderHistoryDTO);
            return _mapper.Map<List<OrderDTO>>(orders);
        }

        public async Task<OrderDTO> UpdateOrderAsync(UpdateOrderDTO updateOrderDTO)
        {
            if (updateOrderDTO == null)
                throw new ArgumentException();

            Order oldOrder = await _unitOfWork.OrderRepository.GetAsync(o => o.Id == updateOrderDTO.Id);
            var oldVersion = oldOrder.ToBsonDocument();
            Order mappedOrder = _mapper.Map<Order>(updateOrderDTO);

            if (updateOrderDTO.OrderDetails != null)
                await UpdateOrderDetailsAsync(updateOrderDTO.OrderDetails);

            Order updatedOrder = await _unitOfWork.OrderRepository.UpdateAsync(mappedOrder);
            await _unitOfWork.SaveAsync();

            _logger.LogInformation($"Order with id :{updatedOrder.Id} has been updated");
            await _mongoLogger.LogInformation<Order>(ActionType.Update, oldVersion, updatedOrder.ToBsonDocument());

            return _mapper.Map<OrderDTO>(updatedOrder);
        }

        public async Task UpdateOrderDetailsAsync(List<OrderDetailsDTO> detailsToUpdate)
        {
            var mappedDetails = _mapper.Map<List<OrderDetails>>(detailsToUpdate);
            var detailsToCancel = await _unitOfWork.OrderDetailsRepository.GetRangeAsync(o => o.OrderId == detailsToUpdate.First().OrderId);
            await CancelReservedGamesAsync(detailsToCancel);
            
            foreach (var details in mappedDetails)
            {
                await _unitOfWork.OrderDetailsRepository.UpdateAsync(details);
            }

            await ReserveGamesAsync(mappedDetails);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> RemoveOrderDetailsAsync(int id)
        {
            List<OrderDetails> detailsToRemove = await _unitOfWork.OrderDetailsRepository.GetRangeAsync(o => o.Id == id);
            await CancelReservedGamesAsync(detailsToRemove);

            bool isDeletedOrderDetails = await _unitOfWork.OrderDetailsRepository.RemoveAsync(od => od.Id == id);
            await _unitOfWork.SaveAsync();

            if (isDeletedOrderDetails)
            {
                _logger.LogInformation($"Order details with id: {id} has been deleted");
                await _mongoLogger.LogInformation<OrderDetails>(ActionType.Delete);
            }
            else
                throw new ArgumentException("Order has not been deleted");

            return isDeletedOrderDetails;
        }

        private async Task<List<Order>> FilterOrdersAsync(OrderFilterDTO orderHistoryDTO)
        {
            var filter = BuildFilter(orderHistoryDTO);
            List<Order> ordersFromStore = await _unitOfWork.OrderRepository.GetRangeAsync(filter, o => o.OrderDetails);
            List<Order> ordersFromNorthwind = await _northwindDbContext.OrderRepository.GetRangeAsync(filter);

            foreach (var order in ordersFromStore)
            {
                if (order.Status == OrderStatus.Opened || order.Status == OrderStatus.Canceled)
                {
                    foreach (var od in order.OrderDetails)
                    {
                        od.Price = null;
                    }
                }
            }

            if (ordersFromNorthwind != null)
            {
                foreach (var item in ordersFromNorthwind)
                {
                    var detailsByOrderId = await _northwindDbContext.OrderDetailsRepository.GetRangeAsync(od => od.OrderId == item.OrderID);
                    var shipper = await _northwindDbContext.ShipperRepository.GetAsync(s => s.ShipperID == item.ShipVia);
                    item.ShipperCompanyName = shipper.CompanyName;
                    item.OrderDetails = detailsByOrderId;
                }
            }
            ordersFromStore.AddRange(ordersFromNorthwind);
            return ordersFromStore;
        }

        private Expression<Func<Order, bool>> BuildFilter(OrderFilterDTO orderHistoryDTO)
        {
            var type = typeof(Order);
            var parameter = Expression.Parameter(type, "o");
            BinaryExpression expression = null;
            foreach (var property in orderHistoryDTO.GetType().GetProperties())
            {
                var value = Expression.Constant(property.GetValue(orderHistoryDTO));
                if (value.Value != null)
                {
                    var operation = property.Name == "From" ? ExpressionType.GreaterThanOrEqual : ExpressionType.LessThanOrEqual;
                    var newBinary = Expression.MakeBinary(operation, Expression.Property(parameter, type.GetProperty("OrderDate")), value);

                    expression = expression == null ? newBinary : Expression.MakeBinary(ExpressionType.AndAlso, expression, newBinary);
                }
            }
            return expression != null ? Expression.Lambda<Func<Order, bool>>(expression, parameter) : null;
        }

        private async Task<bool> ReserveGamesAsync(List<OrderDetails> detailsOfOrder)
        {
            bool isCompletedReserving = true;
            foreach (var item in detailsOfOrder)
            {
                Game gameToReserve = await _gameService.SetGameAsync(item.GameKey);

                if (gameToReserve == null || gameToReserve.UnitsInStock < item.Quantity && gameToReserve.UnitsInStock == 0)
                {
                    await _unitOfWork.OrderDetailsRepository.RemoveAsync(od => od.Id == item.Id);
                    isCompletedReserving = false;

                    await _unitOfWork.SaveAsync();
                }
                else if (gameToReserve.UnitsInStock < item.Quantity && gameToReserve.UnitsInStock != 0)
                {
                    item.Quantity = gameToReserve.UnitsInStock;
                    gameToReserve.UnitsInStock = 0;
                    item.Price = gameToReserve.Price;
                    isCompletedReserving = false;

                    await _unitOfWork.SaveAsync();
                }
                else
                {
                    var oldVersion = gameToReserve.ToBsonDocument();

                    gameToReserve.UnitsInStock -= item.Quantity;
                    item.Price = gameToReserve.Price;

                    if (gameToReserve.TypeOfBase == TypeOfBase.GameStore)
                        await _unitOfWork.GameRepository.UpdateAsync(gameToReserve);
                    else if (gameToReserve.TypeOfBase == TypeOfBase.Northwind)
                        await _northwindDbContext.ProductRepository.UpdateAsync(gameToReserve);

                    _logger.LogInformation($"Game has been update{gameToReserve.Id}");
                    await _mongoLogger.LogInformation<Game>(ActionType.Update, oldVersion, gameToReserve.ToBsonDocument());
                }
            }

            return isCompletedReserving;
        }

        private async Task CancelReservedGamesAsync(List<OrderDetails> detailsToCancel)
        {
            foreach (var item in detailsToCancel)
            {
                Game gameOfItem = await _gameService.SetGameAsync(item.GameKey);

                if (gameOfItem == null)
                {
                    await _unitOfWork.OrderDetailsRepository.RemoveAsync(od => od.Id == item.Id);
                }
                else
                {
                    gameOfItem.UnitsInStock += item.Quantity;
                    item.Price = null;
                    if (gameOfItem.TypeOfBase == TypeOfBase.Northwind)
                        await _northwindDbContext.ProductRepository.UpdateAsync(gameOfItem);
                }

                _logger.LogInformation($"OrderDetails with Id :{gameOfItem.Id} has been deleted");
                await _mongoLogger.LogInformation<OrderDetails>(ActionType.Delete);
            }
        }

        private async Task GetDetailsByOrderAsync(Order order)
        {
            foreach (var item in order.OrderDetails)
            {
                item.Game = await _unitOfWork.GameRepository.GetAsync(g => g.Key == item.GameKey);
                item.Game = item.Game ?? await _northwindDbContext.ProductRepository.GetAsync(g => g.Key == item.GameKey);
                if (item.Game == null)
                    throw new KeyNotFoundException($"Games of order with id:{order.Id} not found");
            }
        }
    }
}
