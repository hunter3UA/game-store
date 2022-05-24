using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameStore.DAL.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
            OrderDate = DateTime.Now;
        }
        
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [DefaultValue(null)]
        public DateTime? Expiration { get; set; }

        [Required,DefaultValue(OrderStatus.Opened)]
        public OrderStatus Status { get; set; }

        public IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
