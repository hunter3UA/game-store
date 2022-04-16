using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameStore.DAL.Entities
{
    [Index("Type", IsUnique = true)]
    public class PlatformType
    {
        [Key]
        public int PlatformTypeId { get; set; }
        [Required, MaxLength(50)]
        public string Type { get; set; }
        [Required]
        public List<Game> Games { get; set; }

        [Required, DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public PlatformType()
        {
            Games = new List<Game>();
        }



    }
}
