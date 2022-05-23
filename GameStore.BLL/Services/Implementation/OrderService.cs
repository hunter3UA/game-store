using AutoMapper;
using GameStore.BLL.DTO.Order;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public OrderService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderDTO> MakeOrderAsync(int orderId)
        {
            Order orderById = await _unitOfWork.OrderRepository.GetAsync(o => o.Id == orderId && o.Status == OrderStatus.Opened, od => od.OrderDetails);
            bool isCompletedReserving = await ReserveGame(orderById.OrderDetails);

            if (!isCompletedReserving)
            {
                return null;
            }

            orderById.Status = OrderStatus.Processed;
            Order updatedOrder =  await _unitOfWork.OrderRepository.UpdateAsync(orderById,od=>od.OrderDetails);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<OrderDTO>(updatedOrder);
        }

        public async Task<bool> CancelOrderAsync(int orderId)
        {
            Order orderById = await _unitOfWork.OrderRepository.GetAsync(o => o.Id == orderId && o.Status == OrderStatus.Processed, od => od.OrderDetails);

            if (orderById != null)
            {
                await ClearReservedGamesAsync(orderById);
            }

            orderById.Status = OrderStatus.Canceled;
            Order canceledOrder = await _unitOfWork.OrderRepository.UpdateAsync(orderById);
            await _unitOfWork.SaveAsync();
            return true;
        }

        private async Task ClearReservedGamesAsync(Order orderToCancel)
        {
            foreach (var item in orderToCancel.OrderDetails)
            {
                Game gameOfItem = await _unitOfWork.GameRepository.GetAsync(g => g.Id == item.GameId);
                gameOfItem.UnitsInStock += item.Quantity;

                await _unitOfWork.OrderDetailsRepository.RemoveAsync(o => o.Id == item.Id);
                await _unitOfWork.GameRepository.UpdateAsync(gameOfItem);
            }

            await _unitOfWork.SaveAsync();

        }

        private async Task<bool> ReserveGame(IEnumerable<OrderDetails> detailsOfOrder)
        {
            bool isCompletedReserving = true;
            foreach (var item in detailsOfOrder)
            {
                Game gameToReserve = await _unitOfWork.GameRepository.GetAsync(g => g.Id == item.GameId);

                if (gameToReserve.UnitsInStock < item.Quantity && gameToReserve.UnitsInStock != 0)
                {
                    item.Quantity = gameToReserve.UnitsInStock;
                    gameToReserve.UnitsInStock = 0;

                    isCompletedReserving = false;
                }
                else if (gameToReserve.UnitsInStock < item.Quantity && gameToReserve.UnitsInStock == 0)
                {
                    await _unitOfWork.OrderDetailsRepository.RemoveAsync(od=>od.Id==item.Id);
                    isCompletedReserving = false;
                }
                else
                {
                    gameToReserve.UnitsInStock -= item.Quantity;
                    await _unitOfWork.GameRepository.UpdateAsync(gameToReserve);
                }
            }
            await _unitOfWork.SaveAsync();

            return isCompletedReserving;
        }


    }
}
