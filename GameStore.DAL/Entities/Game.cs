using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GameStore.DAL.Attributes;
using Microsoft.EntityFrameworkCore;
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

        [Required, MaxLength(150),BsonElement("ProductName")]
        public string Name { get; set; }

        [Required, MaxLength(5000)]
        public string Description { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public IEnumerable<PlatformType> PlatformTypes { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public IEnumerable<OrderDetails> OrderDetails { get; set; }

        [Required, Range(0.1, 10000)]
        public decimal Price { get; set; }

        [Required, DefaultValue(false)]
        public bool Discontinued { get; set; }

        [Required, Range(0, short.MaxValue)]
        public short UnitsInStock { get; set; }

        public int? PublisherId { get; set; }

        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }
        
        [Required,DefaultValue(0)]
        public int NumberOfViews { get; set; }

        public DateTime AddedAt { get; set; }

        public DateTime PublishedAt { get; set; }

        [DefaultValue(0)]
        public int UnitsOnOrder { get; set; }
        
        [DefaultValue(0)]
        public int ReorderLevel { get; set; }

        public string QuantityPerUnit { get; set; }

        [DefaultValue(false)]
        public bool IsNorthwindGame { get; set; }

        public Game()
        {
            AddedAt = DateTime.UtcNow;
        }
    }
}
