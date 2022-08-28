using GameStore.DAL.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.DAL.Entities.GameStore
{
    public abstract class BaseEntity
    {
        [NotMapped, BsonId, BsonElement("_id")]
        public ObjectId ObjectId { get; set; } = ObjectId.GenerateNewId();

        [Key, IgnoreMongoUpdate]
        public int Id { get; set; }

        [Required, DefaultValue(false), IgnoreMongoUpdate]
        public bool IsDeleted { get; set; }
    }
}
