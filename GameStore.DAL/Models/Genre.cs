using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.DAL.Models
{
    [Index("Name", IsUnique = true)]
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<Game> Games { get; set; } = new List<Game>();

        [Column("fk_ParentId")]
        public int? ParentGenreId { get; set; }
        [ForeignKey("ParentGenreId")]
        public List<Genre> SubGenres { get; set; } = new List<Genre>();

    }
}
