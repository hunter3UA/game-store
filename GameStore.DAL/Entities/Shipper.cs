using GameStore.DAL.Attributes;
using MongoDB.Bson.Serialization.Attributes;

namespace GameStore.DAL.Entities
{
    [MongoCollection("shippers")]
    [BsonIgnoreExtraElements]
    public class Shipper : BaseEntity
    {
        public int ShipperID { get; set; }

        public string CompanyName { get; set; }

        public string Phone { get; set; }
    }
}
