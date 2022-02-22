using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameStore.DAL.Models
{
    [Index("Name",IsUnique =true)]
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<Game> Games { get; set; }=new List<Game>();
        public List<SubGenre> SubGenres { get; set; } = new List<SubGenre>();

    }
}
