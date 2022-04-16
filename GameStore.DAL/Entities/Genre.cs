using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.DAL.Entities
{
    [Index("Name", IsUnique = true)]
    public class Genre
    {
        public int GenreId { get; set; }
        [Required,MaxLength(150)]
        public string Name { get; set; }
        [Required]
        public List<Game> Games { get; set; }
        public int? ParentGenreId { get; set; }
        [ForeignKey("ParentGenreId")]
        public List<Genre> SubGenres { get; set; }
        [Required,DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public Genre()
        {
            Games = new List<Game>();
            SubGenres = new List<Genre>();
        }

    }
}
