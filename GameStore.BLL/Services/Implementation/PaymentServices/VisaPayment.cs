using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Implementation.PaymentServices
{
    public class VisaPayment : IPaymentStrategy
    {
        public async Task<object> PayAsync(int orderId, IUnitOfWork unitOfWork)
        {
            Order orderById = await unitOfWork.OrderRepository.GetAsync(o => o.Id == orderId && o.Status == OrderStatus.Processing);

            if (orderById == null)
                throw new KeyNotFoundException("Order not found");
            
            orderById.Status = OrderStatus.Succeeded;
            await unitOfWork.SaveAsync();

            return true;
        }
    }
}
