using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GameStore.DAL.Entities.Games;
using GameStore.DAL.Entities.GameStore;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson.Serialization.Attributes;

namespace GameStore.DAL.Entities.Genres
{
    [Index("Name", IsUnique = true)]
    public class Genre : BaseEntity
    {
        [Required, MaxLength(150)]
        public string Name { get; set; }

        public IEnumerable<Game> Games { get; set; }

        public int? ParentGenreId { get; set; }

        [ForeignKey(nameof(ParentGenreId))]
        public IEnumerable<Genre> SubGenres { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [DefaultValue(null)]
        public int? CategoryId { get; set; }

        public IEnumerable<GenreTranslate> Translations { get; set; }

    }
}
