using GameStore.DAL.Attributes;
using GameStore.DAL.Entities.GameStore;
using MongoDB.Bson.Serialization.Attributes;

namespace GameStore.DAL.Entities.Northwind
{
    [MongoCollection("shippers")]
    [BsonIgnoreExtraElements]
    public class Shipper : NorthwindBaseEntity
    {
        public int ShipperID { get; set; }

        public string CompanyName { get; set; }

        public string Phone { get; set; }
    }
}
