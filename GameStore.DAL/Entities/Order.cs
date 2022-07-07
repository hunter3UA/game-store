using GameStore.DAL.Attributes;
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

        [Required, BsonSerializer(typeof(CustomDateTimeConverter))]
        public DateTime OrderDate { get; set; }

        [DefaultValue(null), BsonSerializer(typeof(CustomDateTimeConverterNullable)), BsonElement("RequiredDate")]
        public DateTime? Expiration { get; set; }

        [Required, DefaultValue(OrderStatus.Opened)]
        public OrderStatus Status { get; set; }

        public IEnumerable<OrderDetails> OrderDetails { get; set; }

        public double? Freight { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCity { get; set; }

        public string ShipCountry { get; set; }

        public string ShipName { get; set; }

        [BsonSerializer(typeof(CustomDateTimeConverterNullable))]
        public DateTime? ShippedDate { get; set; }

        [BsonSerializer(typeof(CustomStringConverter))]
        public string ShipPostalCode { get; set; }

        public string ShipRegion { get; set; }

        public int ShipVia { get; set; }

        [NotMapped]
        public string ShipperCompanyName { get; set; }

        [NotMapped]
        public int OrderID { get; set; }

        public Order()
        {
            OrderDate = DateTime.UtcNow;
        }
    }
}
