namespace GameStore.BLL.DTO.OrderDetails
{
    public class OrderDetailsDTO
    {
        public int Id { get; set; }

        public short Quantity { get; set; }

        public int CustomerId { get; set; }

        public double Price { get; set; }

        public double Discount { get; set; }

        public int OrderId { get; set; }

        public double Total { 
            get
            {
                return Quantity * Price;
            }
        }
    }
}
