using GameStore.DAL.Attributes;
using GameStore.DAL.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace GameStore.DAL.Entities.Northwind
{
    [MongoCollection("suppliers")]
    [BsonIgnoreExtraElements]
    public class Supplier : NorthwindBaseEntity
    {
        public int SupplierID { get; set; }

        public string CompanyName { get; set; }

        public string HomePage { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        public string Country { get; set; }

        public string Region { get; set; }

        public string Fax { get; set; }

        public string Phone { get; set; }

        public string PostalCode { get; set; }

        [BsonDefaultValue(TypeOfBase.Northwind), IgnoreMongoUpdate]
        public TypeOfBase TypeOfBase { get; set; }
    }
}
