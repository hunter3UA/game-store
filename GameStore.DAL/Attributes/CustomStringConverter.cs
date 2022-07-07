using MongoDB.Bson;
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
            var type = context.Reader.GetCurrentBsonType();
            string convertedField = string.Empty;
            switch (type)
            {
                case BsonType.Double:
                    convertedField = context.Reader.ReadDouble().ToString();
                    break;
                case BsonType.Int32:
                    convertedField = context.Reader.ReadInt32().ToString();
                    break;
                case BsonType.Int64:
                    convertedField = context.Reader.ReadInt64().ToString();
                    break;
                case BsonType.String:
                    convertedField = context.Reader.ReadString();
                    break;
                case BsonType.Null:
                    context.Reader.ReadNull();
                    return null;
            }

            return convertedField;
        }
    }
}
