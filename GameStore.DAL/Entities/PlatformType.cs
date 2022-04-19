using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameStore.DAL.Entities
{
    [Index("Type", IsUnique = true)]
    public class PlatformType:BaseEntity
    {
        [Required, MaxLength(50)]
        public string Type { get; set; }

            
        public List<Game> Games { get; set; }

        public PlatformType()
        {
            Games = new List<Game>();
        }
    }
}
