using GameStore.DAL.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.DAL.Entities
{
    public abstract class BaseEntity
    {
        [Key, BsonIgnore, IgnoreMongoUpdate]
        public int Id { get; set; }

        [NotMapped, BsonElement("_id")]
        public ObjectId ObjectId { get; set; }

        [Required, DefaultValue(false), IgnoreMongoUpdate]
        public bool IsDeleted { get; set; }
    }
}
