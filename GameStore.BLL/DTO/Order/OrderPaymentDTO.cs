using GameStore.BLL.Enum;

namespace GameStore.BLL.DTO.Order
{
    public class OrderPaymentDTO
    {
        public int OrderId { get; set; }

        public PaymentType PaymentType { get; set; }

        public int ShipVia { get; set; }

        public string ShipName { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCity { get; set; }

        public string ShipPostalCode { get; set; }

        public string ShipCountry { get; set; }

        public string ShipRegion { get; set; }

    }
}
