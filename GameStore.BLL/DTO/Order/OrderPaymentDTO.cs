using GameStore.BLL.Enum;

namespace GameStore.BLL.DTO.Order
{
    public class OrderPaymentDTO
    {
        public int OrderId { get; set; }

        public PaymentType PaymentType { get; set; }
    }
}
