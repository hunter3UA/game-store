using GameStore.DAL.UoW.Abstract;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstract
{
    public interface IPaymentStrategy
    {
        Task<object> PayAsync(int orderId, IUnitOfWork unitOfWork);
    }
}
