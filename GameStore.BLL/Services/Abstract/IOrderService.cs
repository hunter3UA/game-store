using GameStore.BLL.DTO.Order;
using GameStore.BLL.Enum;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstract
{
    public interface IOrderService
    {
        Task<OrderDTO> MakeOrderAsync(int orderId);

        Task<bool> CancelOrderAsync(int orderId);

        Task<OrderDTO> GetOrderAsync(int orderId);
    }
}
