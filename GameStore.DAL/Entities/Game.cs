using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameStore.DAL.Entities
{
    [Index("Name", IsUnique = true)]
    public class Game:BaseEntity
    {
       
        

        [Required, MaxLength(150)]
        public string Name { get; set; }

        [Required,MaxLength(5000)]
        public string Description { get; set; }

        public List<Comment> Comments { get; set; } 

        [Required]
        public List<PlatformType> PlatformTypes { get; set; } 

        [Required]
        public List<Genre> Genres { get; set; }


        public Game()
        {
            Comments = new List<Comment>();
            PlatformTypes = new List<PlatformType>();
            Genres = new List<Genre>();
        }

    }
}
