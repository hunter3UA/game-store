using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.BLL.DTO.Auth;
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

namespace GameStore.BLL.Services.Implementation
{
    public class BasketService : IBasketService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INorthwindFactory _northwindFactory;
        private readonly IGameService _gameService;
        private readonly ILogger<BasketService> _logger;
        private readonly IMongoLoggerProvider _mongoLogger;

        public BasketService(IGameService gameService, IMapper mapper, IUnitOfWork unitOfWork, ILogger<BasketService> logger, INorthwindFactory northwindDbContext, IMongoLoggerProvider mongoLogger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _northwindFactory = northwindDbContext;
            _mongoLogger = mongoLogger;
            _gameService = gameService;
        }

        public async Task<OrderDetailsDTO> AddOrderDetailsAsync(string gameKey, string customerId)
        {
            Game gameOfDetails = await _gameService.SetGameAsync(gameKey);

            if (gameOfDetails.UnitsInStock <= 0)
                throw new ArgumentException("Value must be greater than 0");

            Order orderOfCustomer = await _unitOfWork.OrderRepository.GetAsync(g => g.CustomerId == customerId && g.Status != OrderStatus.Succeeded);
            if (orderOfCustomer == null)
                orderOfCustomer = await CreateOrderAsync(customerId);
            else if (orderOfCustomer.Status == OrderStatus.Processing)
                throw new ArgumentException("Order detils can not be added to order with Processing status");

            OrderDetails orderItemToAdd = await _unitOfWork.OrderDetailsRepository.GetAsync(od => od.OrderId == orderOfCustomer.Id && od.GameKey == gameOfDetails.Key);
            if (orderItemToAdd != null)
                return _mapper.Map<OrderDetailsDTO>(orderItemToAdd);

            OrderDetails addedOrderDetails = await CreateOrderDetailsAsync(orderOfCustomer.Id, gameOfDetails.Key);

            return _mapper.Map<OrderDetailsDTO>(addedOrderDetails);
        }

        public async Task<bool> RemoveOrderDetailsAsync(int id)
        {
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

        public async Task<OrderDTO> GetBasketAsync(string customerId)
        {
            Order orderByCustomer = await _unitOfWork.OrderRepository.GetAsync(o => o.CustomerId == customerId && o.Status != OrderStatus.Succeeded, od => od.OrderDetails.Where(o => !o.IsDeleted));

            if (orderByCustomer == null)
                return new OrderDTO();

            var details = orderByCustomer.OrderDetails.ToList();
            for (int i = 0; i < orderByCustomer.OrderDetails.Count(); i++)
            {
                var gameOfDetais = await _unitOfWork.GameRepository.GetAsync(g => g.Key == details[i].GameKey);
                gameOfDetais ??= await _northwindFactory.ProductRepository.GetAsync(g => g.Key == details[i].GameKey);
                details[i].Game = gameOfDetais;
                details[i].Price = gameOfDetais.Price;
                if (orderByCustomer.Status != OrderStatus.Processing && details[i].Game != null && details[i].Game.IsDeleted)
                {
                    await RemoveOrderDetailsAsync(details[i].Id);
                    details.Remove(details[i]);
                }
            }
            orderByCustomer.OrderDetails = details;

            return _mapper.Map<OrderDTO>(orderByCustomer);
        }

        public async Task MergeOrdersAsync(string oldUserId, string newUserId)
        {
            Order oldOrder = await _unitOfWork.OrderRepository.GetAsync(o => o.CustomerId == oldUserId && (o.Status==OrderStatus.Opened || o.Status==OrderStatus.Canceled), o => o.OrderDetails);
            Order newOrder = await _unitOfWork.OrderRepository.GetAsync(o => o.CustomerId == newUserId && (o.Status == OrderStatus.Opened || o.Status == OrderStatus.Canceled), o => o.OrderDetails);
            if (oldOrder == null || !oldOrder.OrderDetails.Any() || oldUserId==newUserId) 
                return;

            if (newOrder == null || !newOrder.OrderDetails.Any())
            {
                oldOrder.CustomerId = newUserId;
                await _unitOfWork.SaveAsync();
                return;
            }

            foreach (var orderDetails in oldOrder.OrderDetails)
            {

                if (IsOrderContainsSameOrderDetails(newOrder, orderDetails))
                {
                    var detailsOfNewOrder = newOrder.OrderDetails.FirstOrDefault(o => o.GameKey == orderDetails.GameKey);
                    var gameOfDetails = await _gameService.SetGameAsync(orderDetails.GameKey);
                    short newQuantity = (short)(detailsOfNewOrder.Quantity + orderDetails.Quantity);
                    detailsOfNewOrder.Quantity = newQuantity <= gameOfDetails.UnitsInStock ? newQuantity : gameOfDetails.UnitsInStock;
                    await _unitOfWork.OrderDetailsRepository.RemoveAsync(o => o.Id == orderDetails.Id);
                }
                else
                {
                    orderDetails.OrderId = newOrder.Id;
                }
                
            }

            await _unitOfWork.SaveAsync();
        }

        public async Task<OrderDetailsDTO> ChangeQuantityOfDetailsAsync(ChangeQuantityDTO changeQuantityDTO)
        {
            OrderDetails orderDetailsToUpdate = await _unitOfWork.OrderDetailsRepository.GetAsync(o => o.Id == changeQuantityDTO.OrderDetailsId);
            Game gameByDetails = await _unitOfWork.GameRepository.GetAsync(g => g.Key == orderDetailsToUpdate.GameKey);
            gameByDetails ??= await _northwindFactory.ProductRepository.GetAsync(g => g.Key == orderDetailsToUpdate.GameKey);

            if (orderDetailsToUpdate == null)
                throw new KeyNotFoundException("Order details not found");

            orderDetailsToUpdate.Quantity = (short)changeQuantityDTO.Quantity;
            if (orderDetailsToUpdate.Quantity > gameByDetails.UnitsInStock || orderDetailsToUpdate.Quantity < 0)
                throw new ArgumentException("Quantity is invalid");

            if (gameByDetails.TypeOfBase == TypeOfBase.Northwind)
                await _northwindFactory.ProductRepository.UpdateAsync(gameByDetails);

            await _unitOfWork.SaveAsync();
            return _mapper.Map<OrderDetailsDTO>(orderDetailsToUpdate);
        }

        private static bool IsOrderContainsSameOrderDetails(Order targetOrder, OrderDetails orderDetail)
        {
            return targetOrder.OrderDetails.Any(details => details.GameKey == orderDetail.GameKey);
        }

        private async Task<Order> CreateOrderAsync(string customerId)
        {
            Order orderToAdd = new Order()
            {
                CustomerId = customerId,
                Status = OrderStatus.Opened
            };
            Order addedOrder = await _unitOfWork.OrderRepository.AddAsync(orderToAdd);
            await _unitOfWork.SaveAsync();

            _logger.LogInformation($"Order with id: {addedOrder.Id} has added");
            await _mongoLogger.LogInformation<Order>(ActionType.Create);

            return addedOrder;
        }

        private async Task<OrderDetails> CreateOrderDetailsAsync(int orderId, string key)
        {
            OrderDetails orderDetailsToAdd = new OrderDetails()
            {
                OrderId = orderId,
                Quantity = 1,
                GameKey = key,
                Discount = 0
            };

            OrderDetails addedOrderDetails = await _unitOfWork.OrderDetailsRepository.AddAsync(orderDetailsToAdd);
            await _unitOfWork.SaveAsync();

            if (addedOrderDetails != null)
            {
                _logger.LogInformation($"OrderDetails with id: {addedOrderDetails.Id} has added");
                await _mongoLogger.LogInformation<OrderDetails>(ActionType.Create);
            }
            else
                throw new ArgumentException("Order details can not be created");

            return addedOrderDetails;
        }

    }
}
