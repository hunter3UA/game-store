using GameStore.DAL.Attributes;
using GameStore.DAL.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.DAL.Entities.Northwind
{
    [MongoCollection("products")]
    [BsonIgnoreExtraElements]
    public class Product : NorthwindBaseEntity
    {
        [Required, MaxLength(500)]
        public string Key { get; set; }

        [Required, MaxLength(150), BsonElement("ProductName")]
        public string Name { get; set; }

        [Required, Range(0.1, 10000), BsonElement("UnitPrice"), BsonRepresentation(BsonType.Double)]
        public decimal Price { get; set; }

        [BsonRepresentation(BsonType.Int32), BsonElement("CategoryID")]
        public int CategoryID { get; set; }

        public int SupplierID { get; set; }

        public int ReorderLevel { get; set; }

        public string QuantityPerUnit { get; set; }

        public int UnitsOnOrder { get; set; }

        public int NumberOfViews { get; set; }

        public short UnitsInStock { get; set; }

        [IgnoreMongoUpdate]
        public TypeOfBase TypeOfBase { get; set; }

        [IgnoreMongoUpdate]
        public DateTime AddedAt { get; set; }

        public Product()
        {
            TypeOfBase = TypeOfBase.Northwind;
        }


    }
}
