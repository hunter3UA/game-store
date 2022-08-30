using GameStore.DAL.Attributes;
using MongoDB.Bson.Serialization.Attributes;

namespace GameStore.DAL.Entities.Northwind
{
    [MongoCollection("order-details")]
    [BsonIgnoreExtraElements]
    public class OrderDetails:NorthwindBaseEntity
    {
        public short Quantity { get; set; }

        public double Discount { get; set; }

        [BsonElement("OrderID")]
        public int OrderId { get; set; }
    }
}
