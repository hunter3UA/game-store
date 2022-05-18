using System.Threading.Tasks;
using GameStore.BLL.DTO.Order;
using GameStore.BLL.DTO.OrderDetails;

namespace GameStore.BLL.Services.Abstract
{
    public interface IOrderService
    {
        Task<OrderDetailsDTO> AddOrderDetailsAsync(string gameKey, int customerId);

        Task<OrderDTO> GetOrderAsync(int cusomerId);

        Task<OrderDetailsDTO> ChangeQuantityOfDetailsAsync(ChangeQuantityDTO changeQuantityDTO);

        Task<bool> RemoveOrderDetailsAsync(int id);
    }
}
