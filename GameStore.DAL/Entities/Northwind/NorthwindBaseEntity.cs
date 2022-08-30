using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameStore.DAL.Entities.Northwind
{
    public abstract class NorthwindBaseEntity
    {
        [BsonId, BsonElement("_id")]
        public ObjectId ObjectId { get; set; } = ObjectId.GenerateNewId();
    }
}
