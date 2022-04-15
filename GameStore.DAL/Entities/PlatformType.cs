using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public IEnumerable<Game> Games { get; set; }
    }
}
