using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameStore.DAL.Entities
{
    [Index("Name","Key", IsUnique = true)] 
    public class Game:BaseEntity
    {
        [Required, MaxLength(500)]
        public string Key { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; }

        [Required,MaxLength(5000)]
        public string Description { get; set; }

        public IEnumerable<Comment> Comments { get; set; } 

        [Required]
        public IEnumerable<PlatformType> PlatformTypes { get; set; } 

        [Required]
        public IEnumerable<Genre> Genres { get; set; }
    }
}
