using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GameStore.DAL.Attributes;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameStore.DAL.Entities
{

    [MongoCollection("products")]
    [BsonIgnoreExtraElements]
    [Index("Name", IsUnique = true)]
    [Index("Key", IsUnique = true)]
    public class Game : BaseEntity
    {
        [Required, MaxLength(500)]
        public string Key { get; set; }

        [Required, MaxLength(150), BsonElement("ProductName")]
        public string Name { get; set; }

        [Required, MaxLength(5000), BsonIgnore]
        public string Description { get; set; }

        [BsonIgnore]
        public IEnumerable<Comment> Comments { get; set; }

        [BsonIgnore]
        public IEnumerable<PlatformType> PlatformTypes { get; set; }

        [BsonIgnore]
        public IEnumerable<Genre> Genres { get; set; }

        [BsonIgnore]
        public IEnumerable<OrderDetails> OrderDetails { get; set; }

        [Required, Range(0.1, 10000), BsonElement("UnitPrice"), BsonRepresentation(BsonType.Double)]
        public decimal Price { get; set; }

        [Required, DefaultValue(false)]
        public bool Discontinued { get; set; }

        [Required, Range(0, short.MaxValue)]
        public short UnitsInStock { get; set; }

        [BsonIgnore]
        public int? PublisherId { get; set; }

        [ForeignKey("PublisherId"), BsonIgnore]
        public Publisher Publisher { get; set; }

        [Required, DefaultValue(0)]
        public int NumberOfViews { get; set; }

        [BsonIgnore]
        public DateTime AddedAt { get; set; }

        [BsonIgnore]
        public DateTime PublishedAt { get; set; }

        [DefaultValue(0)]
        public int UnitsOnOrder { get; set; }

        [DefaultValue(0)]
        public int ReorderLevel { get; set; }

        public string QuantityPerUnit { get; set; }

        [BsonDefaultValue(TypeOfBase.Northwind)]
        public TypeOfBase TypeOfBase { get; set; }

        [NotMapped, BsonRepresentation(BsonType.Int32), BsonElement("CategoryID")]
        public int CategoryID { get; set; }

        [NotMapped]
        public int SupplierID { get; set; }

        public string PublisherName { get; set; }

        public Game()
        {
            AddedAt = DateTime.UtcNow;
            Comments = new List<Comment>();
            
        }
    }
}
