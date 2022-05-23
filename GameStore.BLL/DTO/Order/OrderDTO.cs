using System;
using System.Collections.Generic;
using System.Linq;
using GameStore.BLL.DTO.OrderDetails;

namespace GameStore.BLL.DTO.Order
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public List<OrderDetailsDTO> OrderDetails { get; set; }

        public double TotalSum 
        { 
            get
            {
                return OrderDetails.Sum(o => o.Total);
            } 
        }
    }
}
