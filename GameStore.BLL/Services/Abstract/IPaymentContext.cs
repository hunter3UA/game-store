using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstract
{
    public interface IPaymentContext
    {
        void SetStrategy(IPaymentStrategy paymentStrategy);

        Task<object> ExecutePay(int orderId);
    }
}
