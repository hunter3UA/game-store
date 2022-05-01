using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL.Entities
{
    [Index("Name", IsUnique = true)]
    [Index("Key", IsUnique = true)]
    public class Game : BaseEntity
    {
        [Required, MaxLength(500)]
        public string Key { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; }

        [Required, MaxLength(5000)]
        public string Description { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public IEnumerable<PlatformType> PlatformTypes { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public IEnumerable<OrderDetails> OrderDetails { get; set; }

        [Required, Range(0.1, double.MaxValue)]
        public decimal Price { get; set; }

        [Required, DefaultValue(false)]
        public bool Discounted { get; set; }

        [Required, Range(0, short.MaxValue)]
        public short UnitsInStock { get; set; }

        [Required]
        public int PublisherId { get; set; }

        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }
    }
}
