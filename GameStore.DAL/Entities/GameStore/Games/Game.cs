﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GameStore.DAL.Attributes;
using GameStore.DAL.Entities.GameStore;
using GameStore.DAL.Entities.Genres;
using GameStore.DAL.Entities.Platforms;
using GameStore.DAL.Entities.Publishers;
using GameStore.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameStore.DAL.Entities.Games
{

    [MongoCollection("products")]
    [BsonIgnoreExtraElements]
    [Index("Key", IsUnique = true)]
    public class Game : BaseEntity
    {
        [Required, MaxLength(500)]
        public string Key { get; set; }

        [Required, MaxLength(150), BsonElement("ProductName")]
        public string Name { get; set; }

        [MaxLength(5000), IgnoreMongoUpdate]
        public string Description { get; set; }

        [IgnoreMongoUpdate, BsonIgnore]
        public IEnumerable<Comment> Comments { get; set; }

        [IgnoreMongoUpdate, BsonIgnore]
        public IEnumerable<PlatformType> PlatformTypes { get; set; }

        [IgnoreMongoUpdate, BsonIgnore]
        public IEnumerable<Genre> Genres { get; set; }

        [Required, Range(0.1, 10000), BsonElement("UnitPrice"), BsonRepresentation(BsonType.Double)]
        public decimal Price { get; set; }

        [Required, DefaultValue(false)]
        public bool Discontinued { get; set; }

        [Required, Range(0, short.MaxValue)]
        public short UnitsInStock { get; set; }

        [NotMapped, IgnoreMongoUpdate, BsonIgnore]
        public Publisher Publisher { get; set; }

        [Required, DefaultValue(0)]
        public int NumberOfViews { get; set; }

        [IgnoreMongoUpdate, BsonIgnore]
        public DateTime AddedAt { get; set; }

        [IgnoreMongoUpdate]
        public DateTime PublishedAt { get; set; }

        [DefaultValue(0)]
        public int UnitsOnOrder { get; set; }

        [DefaultValue(0)]
        public int ReorderLevel { get; set; }

        public string QuantityPerUnit { get; set; }

        [NotMapped, BsonDefaultValue(TypeOfBase.Northwind), IgnoreMongoUpdate]
        public TypeOfBase TypeOfBase { get; set; }

        [NotMapped, BsonRepresentation(BsonType.Int32), BsonElement("CategoryID")]
        public int CategoryID { get; set; }

        [NotMapped]
        public int SupplierID { get; set; }

        [IgnoreMongoUpdate]
        public string PublisherName { get; set; }

        [IgnoreMongoUpdate]
        public IEnumerable<GameTranslate> Translations { get; set; }

        public Game()
        {
            AddedAt = DateTime.UtcNow;
            Comments = new List<Comment>();
            PlatformTypes = new List<PlatformType>();
        }
    }
}