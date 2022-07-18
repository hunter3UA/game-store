using GameStore.BLL.Enums;
using GameStore.DAL.Context.Abstract;
using GameStore.DAL.Entities;
using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace GameStore.BLL.Providers
{
    public class MongoLoggerProvider : IMongoLoggerProvider
    {
        private readonly INorthwindDbContext _northwindDbContext;

        public MongoLoggerProvider(INorthwindDbContext northwindDbContext)
        {
            _northwindDbContext = northwindDbContext;
        }

        public async Task LogInformation<T>(ActionType actionType)
        {
            var log = CreateLog<T>(actionType, null, null);

            await _northwindDbContext.LogRepository.AddAsync(log);
        }

        public async Task LogInformation<T>(ActionType actionType, BsonDocument oldVersion, BsonDocument newVersion)
        {     
            var log = CreateLog<T>(actionType, oldVersion, newVersion);

            await _northwindDbContext.LogRepository.AddAsync(log);
        }

        private Log CreateLog<T>(ActionType actionType, BsonDocument oldVersion, BsonDocument newVersion)
        {
            Log newLog = new Log()
            {
                Date = DateTime.UtcNow,
                Action = actionType.ToString(),
                Type = typeof(T).Name,
                OldVersion = oldVersion,
                NewVersion = newVersion
            };
            return newLog;
        }
    }
}
