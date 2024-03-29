﻿using System.Threading.Tasks;
using GameStore.BLL.DTO.Order;
using GameStore.BLL.DTO.OrderDetails;

namespace GameStore.BLL.Services.Abstract
{
    public interface IBasketService
    {
        Task<OrderDetailsDTO> AddOrderDetailsAsync(string gameKey, string customerId);

        Task<OrderDetailsDTO> ChangeQuantityOfDetailsAsync(ChangeQuantityDTO changeQuantityDTO);

        Task<OrderDTO> GetBasketAsync(string cusomerId);

        Task<bool> RemoveOrderDetailsAsync(int id);

        Task MergeOrdersAsync(string oldUserId, string newUserId);
    }
}
