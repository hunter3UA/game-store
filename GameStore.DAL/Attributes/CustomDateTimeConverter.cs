using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Newtonsoft.Json.Converters;
using System;

namespace GameStore.DAL.Attributes
{
    class CustomDateTimeConverter : SerializerBase<DateTime>
    {
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, DateTime value)
        {

        }

        public override DateTime Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var res = context.Reader.ReadString();

            var newDateTime = DateTime.Parse(res);

            return newDateTime;
        }
    }
}
