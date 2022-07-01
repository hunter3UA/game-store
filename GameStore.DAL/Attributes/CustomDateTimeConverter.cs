using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using System;

namespace GameStore.DAL.Attributes
{
    public class CustomDateTimeConverter: SerializerBase<DateTime>
    {
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, DateTime value)
        {

        }

        public override DateTime Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var res = context.Reader.ReadString();
          
            bool isValid =  DateTime.TryParse(res,out var dateTime); 

            return isValid ? dateTime : DateTime.UtcNow;
        }
    }
}
