using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL.Entities
{
    [Index("Type", IsUnique = true)]
    public class PlatformType : BaseEntity
    {
        [Required, MaxLength(50)]
        public string Type { get; set; }

        public IEnumerable<Game> Games { get; set; }
    }
}
