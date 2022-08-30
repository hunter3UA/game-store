using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Context.Abstract;
using GameStore.DAL.Entities.GameStore;
using GameStore.DAL.Enums;
using GameStore.DAL.UoW.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Implementation.PaymentServices
{
    public class VisaPayment : IPaymentStrategy
    {
        public async Task<object> PayAsync(int orderId, IUnitOfWork unitOfWork, INorthwindFactory _northwindDbContext)
        {
            Order orderToPay = await unitOfWork.OrderRepository.GetAsync(o => o.Id == orderId && o.Status == OrderStatus.Processing);

            if (orderToPay == null)
                throw new KeyNotFoundException("Order not found");

            foreach (var item in orderToPay.OrderDetails)
            {
                var gameOfDetails = await unitOfWork.GameRepository.GetAsync(g => g.Key == item.GameKey);
                var productOfDetails = item.Game == null ? await _northwindDbContext.ProductRepository.GetAsync(g => g.Key == item.GameKey) : null;
                if (gameOfDetails == null && productOfDetails==null)
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
