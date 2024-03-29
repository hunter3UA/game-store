﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.BLL.DTO.Order;
using GameStore.BLL.DTO.OrderDetails;
using GameStore.BLL.Enums;
using GameStore.BLL.Services.Abstract;
using GameStore.BLL.Services.Abstract.Games;
using GameStore.DAL.Entities.Games;
using GameStore.DAL.Entities.GameStore;
using GameStore.DAL.Enums;
using GameStore.DAL.UoW.Abstract;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;


namespace GameStore.BLL.Services.Implementation.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderService> _logger;
        private readonly IGameService _gameService;

        public OrderService(IGameService gameService, IUnitOfWork unitOfWork, IMapper mapper, ILogger<OrderService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
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

            _logger.LogInformation($"Status of order with id {updatedOrder.Id} has been changed to Processing");

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
       
            return true;
        }

        public async Task<List<OrderDTO>> GetStoreOrdersAsync(OrderFilterDTO orderFilterDTO)
        {
            Expression<Func<Order,bool>> filter = o=>o.Status!=OrderStatus.Succeeded && o.OrderDate>orderFilterDTO.From && o.OrderDate <= orderFilterDTO.To;  
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

            Order mappedOrder = _mapper.Map<Order>(updateOrderDTO);

            if (updateOrderDTO.OrderDetails != null)
                await UpdateOrderDetailsAsync(updateOrderDTO.OrderDetails);

            Order updatedOrder = await _unitOfWork.OrderRepository.UpdateAsync(mappedOrder);
            await _unitOfWork.SaveAsync();

            _logger.LogInformation($"Order with id :{updatedOrder.Id} has been updated");
          
            return _mapper.Map<OrderDTO>(updatedOrder);
        }

        private async Task UpdateOrderDetailsAsync(List<OrderDetailsDTO> detailsToUpdate)
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
            }
            else
                throw new ArgumentException("Order has not been deleted");

            return isDeletedOrderDetails;
        }

        private async Task<List<DAL.Entities.GameStore.Order>> FilterOrdersAsync(OrderFilterDTO orderHistoryDTO)
        {

            List<Order> ordersFromStore = await _unitOfWork.OrderRepository.GetRangeAsync(o=>o.OrderDate>=orderHistoryDTO.From && o.OrderDate<=orderHistoryDTO.To, o => o.OrderDetails);
            
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

            return ordersFromStore;
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
                    gameToReserve.UnitsInStock -= item.Quantity;
                    item.Price = gameToReserve.Price;

                    await _unitOfWork.GameRepository.UpdateAsync(gameToReserve);
                     
                    _logger.LogInformation($"Game has been update{gameToReserve.Id}");

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
                }

                _logger.LogInformation($"OrderDetails with Id :{gameOfItem.Id} has been deleted");
            }
        }

        private async Task GetDetailsByOrderAsync(Order order)
        {
            foreach (var item in order.OrderDetails)
            {
                item.Game = await _gameService.SetGameAsync(item.GameKey);

                if (item.Price == null)
                    item.Price = item.Game.Price;
            }
        }

    }
}
