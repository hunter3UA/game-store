using GameStore.BLL.DTO.Order;
using GameStore.BLL.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstract
{
    public interface IOrderService
    {
        Task<OrderDTO> MakeOrderAsync(int orderId);

        Task<bool> CancelOrderAsync(int orderId);

        Task<OrderDTO> GetOrderAsync(int orderId);

        Task<List<OrderDTO>> GetListOfOrdersAsync(OrderHistoryDTO orderHistoryDTO);

        Task<OrderDTO> UpdateOrderAsync(UpdateOrderDTO updateOrderDTO);
    }
}
