using GameStore.BLL.DTO.Order;
using GameStore.BLL.DTO.OrderDetails;
using GameStore.BLL.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstract
{
    public interface IOrderService
    {
        Task<OrderDTO> MakeOrderAsync(int orderId);

        Task<bool> CancelOrderAsync(int orderId);

        Task<OrderDTO> GetOrderAsync(string customerId);

        Task<OrderDetailsDTO> ChangeQuantityOfDetailsAsync(ChangeQuantityDTO changeQuantityDTO);

        Task<OrderDTO> GetOrderAsync(int orderId);

        Task<List<OrderDTO>> GetListOfOrdersAsync(OrderFilterDTO orderHistoryDTO);

        Task<OrderDTO> UpdateOrderAsync(UpdateOrderDTO updateOrderDTO);

        Task<List<OrderDTO>> GetStoreOrdersAsync();
    }
}
