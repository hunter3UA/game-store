using GameStore.BLL.DTO.OrderDetails;
using GameStore.DAL.Entities;
using GameStore.DAL.Enums;
using GameStore.DAL.Migrations;
using System;
using System.Collections.Generic;

namespace GameStore.BLL.DTO.Order
{
    public class UpdateOrderDTO
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime Expiration { get; set; }

        public string CustomerId { get; set; }

        public string ShipperCompanyName { get; set; }

        public string ShipName { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCity { get; set; }

        public string ShipPostalCode { get; set; }

        public string ShipCountry { get; set; }

        public string ShipRegion { get; set; }

        public List<OrderDetailsDTO> OrderDetails { get; set; }

        public OrderStatus Status { get; set; }
    }
}
