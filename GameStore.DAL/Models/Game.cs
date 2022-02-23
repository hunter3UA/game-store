using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameStore.DAL.Models
{
    [Index("Name", IsUnique = true)]
    public class Game
    {
        [Key]
        public Guid GameId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        [Required]
        public List<PlatformType> PlatformTypes { get; set; } = new List<PlatformType>();
        [Required]
        public List<Genre> Genres { get; set; } = new List<Genre>();
        [Required]
        public bool IsDeleted { get; set; } = false;

    }
}
