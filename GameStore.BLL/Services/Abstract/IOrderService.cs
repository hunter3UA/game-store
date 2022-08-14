using GameStore.BLL.DTO.Order;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstract
{
    public interface IOrderService
    {
        Task<OrderDTO> MakeOrderAsync(int orderId);

        Task<bool> CancelOrderAsync(int orderId);

        Task<OrderDTO> GetOrderAsync(string customerId);

        Task<bool> RemoveOrderDetailsAsync(int id);

        Task<OrderDTO> GetOrderAsync(int orderId);

        Task<List<OrderDTO>> GetOrderHistoryAsync(OrderFilterDTO orderHistoryDTO);

        Task<OrderDTO> UpdateOrderAsync(UpdateOrderDTO updateOrderDTO);

        Task<List<OrderDTO>> GetStoreOrdersAsync(OrderFilterDTO orderFilterDTO);
    }
}
