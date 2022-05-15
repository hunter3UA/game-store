using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.DAL.Entities
{
    public class OrderDetails : BaseEntity
    {
        [Required, Column(name: "ProductId")]
        public int GameId { get; set; }

        [ForeignKey("GameId")]
        public Game Game { get; set; }

        [Required, Range(0.1, 10000)]
        public decimal Price { get; set; }

        [Required, Range(1, short.MaxValue)]
        public short Quantity { get; set; }

        [Required, DefaultValue(0)]
        public double Discount { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
