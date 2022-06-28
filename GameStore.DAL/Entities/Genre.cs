using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GameStore.DAL.Attributes;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson.Serialization.Attributes;

namespace GameStore.DAL.Entities
{
    [MongoCollection("categories")]
    [Index("Name", IsUnique = true)]
    [BsonIgnoreExtraElements]
    public class Genre : BaseEntity
    {
        [Required, MaxLength(150),BsonElement("CategoryName")]
        public string Name { get; set; }

        public IEnumerable<Game> Games { get; set; }

        public int? ParentGenreId { get; set; }

        [ForeignKey("ParentGenreId")]
        public IEnumerable<Genre> SubGenres { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
