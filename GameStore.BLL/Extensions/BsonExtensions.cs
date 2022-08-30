using MongoDB.Bson;
using Newtonsoft.Json;

namespace GameStore.BLL.Extensions
{
    public static class BsonExtensions
    {
        public static BsonDocument SerializeToBsonDocument<T>(this T objectToSerialize)
        {
            var serializedEntity = JsonConvert.SerializeObject(objectToSerialize, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            var deserializedObject = JsonConvert.DeserializeObject(serializedEntity);

            return deserializedObject.ToBsonDocument();
        }
    }
}
