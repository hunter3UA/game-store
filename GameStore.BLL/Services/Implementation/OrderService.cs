using AutoMapper;
using GameStore.BLL.DTO.Order;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Context.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INorthwindDbContext _northwindDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IUnitOfWork unitOfWork, INorthwindDbContext northwindDbContext, IMapper mapper, ILogger<OrderService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _northwindDbContext = northwindDbContext;
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

            bool isCompletedReserving = await ReserveGame(orderById);

            if (!isCompletedReserving)
                throw new ArgumentException("Order can to be completed");

            _logger.LogInformation($"Games of order with id {orderById.Id} have been reserved");
            orderById.Status = OrderStatus.Processing;
            orderById.Expiration = DateTime.UtcNow.AddMinutes(15);
            Order updatedOrder = await _unitOfWork.OrderRepository.UpdateAsync(orderById, od => od.OrderDetails);
            await _unitOfWork.SaveAsync();

            _logger.LogInformation($"Status of order with id { updatedOrder.Id } has been changed to Processing");

            return _mapper.Map<OrderDTO>(updatedOrder);
        }

        public async Task<OrderDTO> GetOrderAsync(int customerId)
        {
            Order orderByCustomer = await _unitOfWork.OrderRepository.GetAsync(o => o.CustomerId == customerId && o.Status == OrderStatus.Processing, o => o.OrderDetails);

            if (orderByCustomer == null || orderByCustomer.OrderDetails == null)
                throw new KeyNotFoundException("Order not found");

            foreach (var item in orderByCustomer.OrderDetails)
            {
                item.Game = await _unitOfWork.GameRepository.GetAsync(g => g.Key == item.GameKey);
                if (item.Game == null)
                    throw new KeyNotFoundException($"Games of order with id:{orderByCustomer.Id} not found");
            }

            return _mapper.Map<OrderDTO>(orderByCustomer);
        }

        public async Task<bool> CancelOrderAsync(int orderId)
        {
            Order orderById = await _unitOfWork.OrderRepository.GetAsync(o => o.Id == orderId && o.Status == OrderStatus.Processing, od => od.OrderDetails);

            if (orderById == null)
                throw new KeyNotFoundException("Order not found");

            await CancelReservedGamesAsync(orderById);
            orderById.Status = OrderStatus.Canceled;
            Order canceledOrder = await _unitOfWork.OrderRepository.UpdateAsync(orderById);
            await _unitOfWork.SaveAsync();

            _logger.LogInformation($"Order with id {canceledOrder.Id} has been canceled");

            return true;
        }

        public async Task<List<OrderDTO>> GetListOfOrdersAsync(OrderHistoryDTO orderHistoryDTO)
        {
            List<Order> orders = await FilterOrders(orderHistoryDTO);
            return _mapper.Map<List<OrderDTO>>(orders);
        }

        private async Task<List<Order>> FilterOrders(OrderHistoryDTO orderHistoryDTO)
        {
            Expression<Func<Order, bool>> expression = o => o.OrderDate >= orderHistoryDTO.From && o.OrderDate <= orderHistoryDTO.To;
            List<Order> ordersFromStore = await _unitOfWork.OrderRepository.GetRangeAsync(expression);
            List<Order> ordersFromNorthwind = await _northwindDbContext.OrderRepository.GetListAsync();
            ordersFromStore.AddRange(ordersFromNorthwind);
            var filter = BuildFilter(orderHistoryDTO);
            if (filter != null)
                ordersFromStore = ordersFromStore.Where(filter.Compile()).ToList();
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

            return ordersFromStore;
        }

        private Expression<Func<Order, bool>> BuildFilter(OrderHistoryDTO orderHistoryDTO)
        {
            var type = typeof(Order);
            var parameter = Expression.Parameter(type);
            var historyParameter = Expression.Parameter(typeof(OrderHistoryDTO));
            BinaryExpression expression = null;
            foreach (var property in orderHistoryDTO.GetType().GetProperties())
            {
                var prop = Expression.Property(historyParameter,property.Name);
                var value = Expression.Constant(property.GetValue(orderHistoryDTO));
                if (value.Value != null)
                {
                    var operation = property.Name == "From" ? ExpressionType.GreaterThanOrEqual : ExpressionType.LessThanOrEqual;
                    var newBinary = Expression.MakeBinary(operation, Expression.Property(parameter,type.GetProperty("OrderDate")), value);

                    expression = expression == null ? newBinary : Expression.MakeBinary(ExpressionType.AndAlso, expression, newBinary);
                }
            }
            return  expression!=null ? Expression.Lambda<Func<Order, bool>>(expression, parameter) : null;
        }

        private async Task<bool> ReserveGame(Order orderToReserve)
        {
            bool isCompletedReserving = true;
            foreach (var item in orderToReserve.OrderDetails)
            {
                Game gameToReserve = await _unitOfWork.GameRepository.GetAsync(g => g.Key == item.GameKey, g => g.Genres, g => g.PlatformTypes);

                if (gameToReserve == null || gameToReserve.UnitsInStock < item.Quantity && gameToReserve.UnitsInStock == 0)
                {
                    await _unitOfWork.OrderDetailsRepository.RemoveAsync(od => od.Id == item.Id);
                    isCompletedReserving = false;

                    await _unitOfWork.SaveAsync();
                }
                else if (gameToReserve.UnitsInStock < item.Quantity && gameToReserve.UnitsInStock != 0)
                {
                    item.Quantity = gameToReserve.UnitsInStock;
                    isCompletedReserving = false;

                    await _unitOfWork.SaveAsync();
                }
                else
                {
                    gameToReserve.UnitsInStock -= item.Quantity;
                    await _unitOfWork.GameRepository.UpdateAsync(gameToReserve);
                }
            }

            return isCompletedReserving;
        }

        private async Task CancelReservedGamesAsync(Order orderToCancel)
        {
            foreach (var item in orderToCancel.OrderDetails)
            {
                Game gameOfItem = await _unitOfWork.GameRepository.GetAsync(g => g.Key == item.GameKey);
                if (gameOfItem == null)
                    await _unitOfWork.OrderDetailsRepository.RemoveAsync(od => od.Id == item.Id);
                else
                    gameOfItem.UnitsInStock += item.Quantity;
            }
        }

    }
}
