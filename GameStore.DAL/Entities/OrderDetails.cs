using GameStore.DAL.Attributes;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.DAL.Entities
{
    [MongoCollection("order-details")]
    [BsonIgnoreExtraElements]
    public class OrderDetails : BaseEntity
    {
        [Required, Column(name: "GameKey"), BsonIgnore]
        public string GameKey { get; set; }

        [NotMapped, IgnoreMongoUpdate]
        public Game Game { get; set; }

        [Range(0.1, 10000), BsonElement("UnitPrice")]
        public decimal? Price { get; set; }

        [Required, Range(1, short.MaxValue)]
        public short Quantity { get; set; }

        [Required, DefaultValue(0)]
        public double Discount { get; set; }

        [Required, BsonElement("OrderID")]
        public int OrderId { get; set; }

        [ForeignKey("OrderId"), IgnoreMongoUpdate, BsonIgnore]
        public Order Order { get; set; }
    }
}
