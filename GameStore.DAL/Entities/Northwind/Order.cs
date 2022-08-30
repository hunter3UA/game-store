using GameStore.DAL.Attributes;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace GameStore.DAL.Entities.Northwind
{
    [MongoCollection("orders")]
    [BsonIgnoreExtraElements]
    public class Order : NorthwindBaseEntity
    {
        public string CustomerId { get; set; }

        [BsonElement("RequiredDate")]
        public DateTime OrderDate { get; set; }

        public decimal? Freight { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCity { get; set; }

        public string ShipCountry { get; set; }

        public string ShipName { get; set; }

        public DateTime? ShippedDate { get; set; }

        public string ShipPostalCode { get; set; }

        public string ShipRegion { get; set; }

        public int ShipVia { get; set; }

        public string ShipperCompanyName { get; set; }

        public int OrderID { get; set; }

        [IgnoreMongoUpdate]
        public IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
