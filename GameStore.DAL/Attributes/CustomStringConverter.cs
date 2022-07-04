using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace GameStore.DAL.Attributes
{
    public class CustomStringConverter : SerializerBase<string>
    {
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, string value)
        {

        }

        public override string Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            return "";
        }
    }
}
