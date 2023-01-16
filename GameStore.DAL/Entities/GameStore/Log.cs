using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace GameStore.DAL.Entities.GameStore
{

    public class Log
    {
        public DateTime Date { get; set; }

        public string Action { get; set; }

        public string Type { get; set; }

        [BsonIgnoreIfNull]
        public BsonDocument OldVersion { get; set; }

        [BsonIgnoreIfNull]
        public BsonDocument NewVersion { get; set; }
    }
}
