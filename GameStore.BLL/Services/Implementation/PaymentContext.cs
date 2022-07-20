using GameStore.BLL.Providers;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Context.Abstract;
using GameStore.DAL.UoW.Abstract;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Implementation
{
    public class PaymentContext : IPaymentContext
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INorthwindFactory _northwindDbContext;
        private readonly ILogger<PaymentContext> _logger;
        private readonly IMongoLoggerProvider _mongoLogger;
        private IPaymentStrategy _paymentStrategy;
        
        public PaymentContext(IUnitOfWork unitOfWOrk,INorthwindFactory northwindDbContext)
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
