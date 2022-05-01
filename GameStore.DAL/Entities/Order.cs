using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameStore.DAL.Entities
{
    public class Order : BaseEntity
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public IEnumerable<OrderDetails> OrderDetails { get; set; }

        public Order()
        {
            OrderDate = DateTime.Now;
        }
    }
}
