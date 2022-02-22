using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameStore.DAL.Models
{
    [Index("Type", IsUnique = true)]
    public class PlatformType
    {
        [Key]
        public Guid PlatformTypeId { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public List<Game> Games { get; set; } = new List<Game>();
    }
}
