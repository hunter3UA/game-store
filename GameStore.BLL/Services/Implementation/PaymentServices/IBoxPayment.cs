using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Implementation.PaymentServices
{
    public class IBoxPayment : IPaymentStrategy
    {
        public async Task<object> PayAsync(int orderId, IUnitOfWork unitOfWork)
        {
            Order orderToPay = await unitOfWork.OrderRepository.GetAsync(o => o.Id == orderId && o.Status == OrderStatus.Processing);

            if (orderToPay == null)
                throw new KeyNotFoundException("Order not found");

            foreach (var item in orderToPay.OrderDetails)
            {
                item.Game = await unitOfWork.GameRepository.GetAsync(g => g.Key == item.GameKey);
                if (item.Game == null)
                {
                    orderToPay.Status = OrderStatus.Canceled;
                    await unitOfWork.SaveAsync();
                    throw new KeyNotFoundException($"Games with id {item.GameKey} not found");
                }
            }

            orderToPay.Status = OrderStatus.Succeeded;
            await unitOfWork.SaveAsync();

            return true;
        }
    }
}
