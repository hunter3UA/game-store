using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Context.Abstract;
using GameStore.DAL.UoW.Abstract;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Implementation
{
    public class PaymentContext : IPaymentContext
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INorthwindDbContext _northwindDbContext;
        private IPaymentStrategy _paymentStrategy;
        
        public PaymentContext(IUnitOfWork unitOfWOrk,INorthwindDbContext northwindDbContext)
        {
            _unitOfWork = unitOfWOrk;
            _northwindDbContext = northwindDbContext;
        }

        public async Task<object> ExecutePay(int orderId)
        {
            object paymentResult = await _paymentStrategy.PayAsync(orderId, _unitOfWork,_northwindDbContext);

            return paymentResult;
        }

        public void SetStrategy(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }
    }
}
