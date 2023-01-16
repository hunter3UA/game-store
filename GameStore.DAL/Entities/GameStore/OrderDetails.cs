using GameStore.DAL.Entities.Games;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.DAL.Entities.GameStore
{
    public class OrderDetails : BaseEntity
    {
        [Required, Column(name: "GameKey")]
        public string GameKey { get; set; }

        [NotMapped]
        public Game Game { get; set; }

        [Range(0.1, 10000)]
        public decimal? Price { get; set; }

        [Required, Range(1, short.MaxValue)]
        public short Quantity { get; set; }

        [Required, DefaultValue(0)]
        public double Discount { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }
    }
}
