using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.BLL.DTO.Order;
using GameStore.BLL.DTO.OrderDetails;
using GameStore.BLL.Enums;
using GameStore.BLL.Extensions;
using GameStore.BLL.Providers;
using GameStore.BLL.Services.Abstract;
using GameStore.BLL.Services.Abstract.Games;
using GameStore.DAL.Context.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.Enums;
using GameStore.DAL.UoW.Abstract;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;


namespace GameStore.BLL.Services.Implementation.Orders
{
    public class OrderUpdateService : IOrderUpdateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INorthwindFactory _northwindDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderService> _logger;
        private readonly IGameService _gameService;
        private readonly IMongoLoggerProvider _mongoLogger;

        public OrderUpdateService(IGameService gameService, IUnitOfWork unitOfWork, INorthwindFactory northwindDbContext, IMapper mapper, ILogger<OrderService> logger, IMongoLoggerProvider mongoLogger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _northwindDbContext = northwindDbContext;
            _mongoLogger = mongoLogger;
            _gameService = gameService;
        }

        public async void ChooseUpdate(UpdateOrderDTO updateOrderDTO)
        {
            Order mappedOrder = _mapper.Map<Order>(updateOrderDTO);

            await _unitOfWork.OrderRepository.UpdateAsync(mappedOrder);
            await _unitOfWork.SaveAsync();

            if (updateOrderDTO.Status == OrderStatus.Opened)
            {
                await ChangeToOpened(updateOrderDTO.OrderDetails, updateOrderDTO.OldStatus);
            }


        }

        public async Task ChangeToOpened(List<OrderDetailsDTO> detailsOfOrder, OrderStatus oldStatus)
        {

            if (oldStatus == OrderStatus.Processing)
            {
                //await CancelReservedGamesAsync()
            }

        }

        public async Task ChangeToProcessingAndCompleted(List<OrderDetailsDTO> detailsOfOrder, OrderStatus oldStatus)
        {

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

                    if (gameToReserve.TypeOfBase == TypeOfBase.GameStore)
                        await _unitOfWork.GameRepository.UpdateAsync(gameToReserve);
                    else if (gameToReserve.TypeOfBase == TypeOfBase.Northwind)
                        await _northwindDbContext.ProductRepository.UpdateAsync(gameToReserve);

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
/*
 Opened -> Opened  - 
 Opened -> Processing  Reserve
 Opened -> Completed  Reserve + change status 

 Processing -> Opened  Cancel reserved games
 Porcessing -> Processing Cancel reserved - Update - Reserve
 Porcessing -> Completed  change status 

 
 
 
 
 
 */