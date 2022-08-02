using System;
using System.Collections.Generic;
using System.Linq;
using GameStore.BLL.DTO.OrderDetails;
using GameStore.BLL.Enum;
using GameStore.DAL.Entities;
using GameStore.DAL.Enums;

namespace GameStore.BLL.DTO.Order
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime Expiration { get; set; }
   
        public OrderStatus Status { get; set; }

        public List<OrderDetailsDTO> OrderDetails { get; set; }

        public double? Freight { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCity { get; set; }

        public string ShipCountry { get; set; }

        public string ShipName { get; set; }

        public DateTime? ShippedDate { get; set; }

        public string ShipPostalCode { get; set; }

        public string ShipRegion { get; set; }

        public string ShipperCompanyName { get; set; }

        public double TotalSum 
        { 
            get
            {
                if (OrderDetails != null)
                    return OrderDetails.Sum(o => o.Total);
                else
                    return 0;
            } 
        }
    }
}
