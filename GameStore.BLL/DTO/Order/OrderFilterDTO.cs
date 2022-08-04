using System;

namespace GameStore.BLL.DTO.Order
{
    public class OrderFilterDTO
    {
        public DateTime? From { get; set; }

        public DateTime? To { get; set; }
    }
}
