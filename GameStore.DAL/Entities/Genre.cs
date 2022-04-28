using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL.Entities
{
    [Index("Name", IsUnique = true)]
    public class Genre : BaseEntity
    {
        [Required, MaxLength(150)]
        public string Name { get; set; }

        public IEnumerable<Game> Games { get; set; }

        public int? ParentGenreId { get; set; }

        [ForeignKey("ParentGenreId")]
        public IEnumerable<Genre> SubGenres { get; set; }
    }
}
