using GameStore.BLL.DTO.Order;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstract
{
    public interface IOrderService
    {

        Task<OrderDTO> MakeOrderAsync(int orderId);

        Task<bool> CancelOrderAsync(int orderId);
    }
}
