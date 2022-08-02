using GameStore.DAL.Attributes;
using GameStore.DAL.Enums;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.DAL.Entities
{
    [MongoCollection("orders")]
    [BsonIgnoreExtraElements]
    public class Order : BaseEntity
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [DefaultValue(null), BsonElement("RequiredDate")]
        public DateTime? Expiration { get; set; }

        [Required, DefaultValue(OrderStatus.Opened)]
        public OrderStatus Status { get; set; }

        
        public IEnumerable<OrderDetails> OrderDetails { get; set; }

        [DefaultValue(0)]
        public decimal? Freight { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCity { get; set; }

        public string ShipCountry { get; set; }

        public string ShipName { get; set; }

        public DateTime? ShippedDate { get; set; }

        public string ShipPostalCode { get; set; }

        public string ShipRegion { get; set; }

        [NotMapped]
        public int ShipVia { get; set; }
       
        public string ShipperCompanyName { get; set; }

        [NotMapped]
        public int OrderID { get; set; }

        public Order()
        {
            OrderDate = DateTime.UtcNow;
        }
    }
}
