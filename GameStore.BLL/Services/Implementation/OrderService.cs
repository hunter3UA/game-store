using AutoMapper;
using GameStore.BLL.DTO.Order;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderDTO> MakeOrderAsync(int orderId)
        {
            Order orderById = await _unitOfWork.OrderRepository.GetAsync(
                o => o.Id == orderId && 
                o.Status != OrderStatus.Processing && 
                o.Status != OrderStatus.Succeeded, 
                od => od.OrderDetails);

            if (orderById == null || orderById.OrderDetails==null)
            {
                return null;
            }

            bool isCompletedReserving = await ReserveGame(orderById);

            if (!isCompletedReserving)
            {
                return null;
            }

            orderById.Status = OrderStatus.Processing;
            orderById.Expiration = DateTime.UtcNow.AddMinutes(15);
            Order updatedOrder = await _unitOfWork.OrderRepository.UpdateAsync(orderById, od => od.OrderDetails);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<OrderDTO>(updatedOrder);
        }

        public async Task<OrderDTO> GetOrderAsync(int customerId)
        {
            Order orderByCustomer = await _unitOfWork.OrderRepository.GetAsync(o => o.CustomerId == customerId && o.Status == OrderStatus.Processing, o => o.OrderDetails);

            if (orderByCustomer == null)
            {
                return null;
            }

            foreach (var item in orderByCustomer.OrderDetails)
            {
                item.Game = await _unitOfWork.GameRepository.GetAsync(g => g.Id == item.GameId);
            }

            return _mapper.Map<OrderDTO>(orderByCustomer);
        }

        public async Task<bool> CancelOrderAsync(int orderId)
        {
            Order orderById = await _unitOfWork.OrderRepository.GetAsync(o => o.Id == orderId && o.Status == OrderStatus.Processing, od => od.OrderDetails);

            if (orderById == null)
            {
                return false;
            }

            await CancelReservedGamesAsync(orderById);
            orderById.Status = OrderStatus.Canceled;
            Order canceledOrder = await _unitOfWork.OrderRepository.UpdateAsync(orderById);
            await _unitOfWork.SaveAsync();
            return true;
        }

        private async Task<bool> ReserveGame(Order orderToReserve)
        {
            bool isCompletedReserving = true;
            foreach (var item in orderToReserve.OrderDetails)
            {
                Game gameToReserve = await _unitOfWork.GameRepository.GetAsync(g => g.Id == item.GameId, g => g.Genres, g => g.PlatformTypes);

                if (gameToReserve.UnitsInStock < item.Quantity && gameToReserve.UnitsInStock != 0)
                {
                    item.Quantity = gameToReserve.UnitsInStock;
                    isCompletedReserving = false;

                    await _unitOfWork.SaveAsync();
                }
                else if (gameToReserve.UnitsInStock < item.Quantity && gameToReserve.UnitsInStock == 0)
                {
                    await _unitOfWork.OrderDetailsRepository.RemoveAsync(od => od.Id == item.Id);
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
                Game gameOfItem = await _unitOfWork.GameRepository.GetAsync(g => g.Id == item.GameId);
                gameOfItem.UnitsInStock += item.Quantity;
            }
        }
    }
}
