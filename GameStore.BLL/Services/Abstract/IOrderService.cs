using GameStore.BLL.DTO.Order;
using GameStore.BLL.DTO.OrderDetails;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstract
{
    public interface IOrderService
    {
        Task<OrderDetailsDTO> AddOrderDetailsAsync(string gameKey, AddOrderDetailsDTO addOrderDetailsDTO);

        Task<OrderDTO> GetOrderAsync();

        Task<OrderDetailsDTO> ChangeQuantityOfDetails(ChangeQuantityDTO changeQuantityDTO);
    }
}
