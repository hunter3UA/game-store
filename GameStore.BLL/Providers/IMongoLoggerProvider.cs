using GameStore.BLL.Enums;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace GameStore.BLL.Providers
{
    public interface IMongoLoggerProvider
    {
        Task LogInformation<T>(ActionType actionType);

        Task LogInformation<T>(ActionType actionType, BsonDocument oldVersion, BsonDocument newVersion);
    }
}
