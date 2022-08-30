using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GameStore.DAL.Entities.GameStore;
using GameStore.DAL.Entities.Genres;
using GameStore.DAL.Entities.Platforms;
using GameStore.DAL.Entities.Publishers;
using GameStore.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace GameStore.DAL.Entities.Games
{
    [Index("Key", IsUnique = true)]
    public class Game : BaseEntity
    {
        [Required, MaxLength(500)]
        public string Key { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(5000)]
        public string Description { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public IEnumerable<PlatformType> PlatformTypes { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        [Required, Range(0.1, 10000)]
        public decimal Price { get; set; }

        [Required, DefaultValue(false)]
        public bool Discontinued { get; set; }

        [Required, Range(0, short.MaxValue)]
        public short UnitsInStock { get; set; }

        [NotMapped]
        public Publisher Publisher { get; set; }

        [Required, DefaultValue(0)]
        public int NumberOfViews { get; set; }

        public DateTime AddedAt { get; set; }

        public DateTime PublishedAt { get; set; }

        [DefaultValue(0)]
        public int UnitsOnOrder { get; set; }

        [DefaultValue(0)]
        public int ReorderLevel { get; set; }

        public string QuantityPerUnit { get; set; }

        [NotMapped, DefaultValue(TypeOfBase.GameStore)]
        public TypeOfBase TypeOfBase { get; set; }

        [NotMapped]
        public int CategoryID { get; set; }

        [NotMapped]
        public int SupplierID { get; set; }

        public string PublisherName { get; set; }

        public IEnumerable<GameTranslate> Translations { get; set; }

        public Game()
        {
            AddedAt = DateTime.UtcNow;
            Comments = new List<Comment>();
            PlatformTypes = new List<PlatformType>();
        }
    }
}
