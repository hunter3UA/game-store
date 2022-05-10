namespace GameStore.BLL.DTO.OrderDetails
{
    public class AddOrderDetailsDTO
    {
        public short Quantity { get; set; }

        public int CustomerId { get; set; }

        public double Price { get; set; }
    }
}
