using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GameStore.DAL.Models
{
    public class SubGenre
    {
        [Key]
        public Guid SubGenreId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required,Column("fk_GenreId")]
        public int GenreId { get; set; }
        [Required,ForeignKey("GenreId")]
        public Genre Genre { get; set; }
    }
}
