using GameStore.DAL.Entities.GameStore;
using GameStore.DAL.Repositories.Abstract;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace GameStore.DAL.Repositories.Implementation
{
    public class NorthwindLogRepository : INorthwindLogRepository
    {
        private readonly IMongoDatabase _db;
        private readonly IMongoCollection<Log> _collection;

        public NorthwindLogRepository(IMongoClient client, IConfiguration _config)
        {
            _db = client.GetDatabase(_config.GetConnectionString("NorthwindDbName"));
            _collection = _db.GetCollection<Log>("logs");
        }

        public async Task AddAsync(Log log)
        {
            await _collection.InsertOneAsync(log);
        }
    }
}
