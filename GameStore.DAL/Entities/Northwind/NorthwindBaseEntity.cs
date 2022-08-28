namespace GameStore.DAL.Entities.Northwind
{
    public abstract class NorthwindBaseEntity
    {
        //[NotMapped, BsonId, BsonElement("_id")]
        //public ObjectId ObjectId { get; set; } = ObjectId.GenerateNewId();

        //[Key, IgnoreMongoUpdate]
        //public int Id { get; set; }

        //[Required, DefaultValue(false), IgnoreMongoUpdate]
        //public bool IsDeleted { get; set; }
    }
}
