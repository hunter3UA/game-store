using GameStore.DAL.Attributes;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;

namespace GameStore.DAL.Entities.Northwind
{
    [MongoCollection("categories")]
    [BsonIgnoreExtraElements]
    public class Category : NorthwindBaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        [BsonElement("CategoryID"), DefaultValue(null)]
        public int? CategoryId { get; set; }
    }
}
