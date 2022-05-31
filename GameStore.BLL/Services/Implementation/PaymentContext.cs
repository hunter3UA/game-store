using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Implementation
{
    public class PaymentContext : IPaymentContext
    {
        private readonly IUnitOfWork _unitOfWork;
        private IPaymentStrategy _paymentStrategy;
        
        public PaymentContext(IUnitOfWork unitOfWOrk)
        {
            _unitOfWork = unitOfWOrk;
        }

        public async Task<object> ExecutePay(int orderId)
        {


            object paymentResult = await _paymentStrategy.PayAsync(orderId, _unitOfWork);

            return paymentResult;
        }

        public void SetStrategy(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }
    }
}
