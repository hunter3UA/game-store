using GameStore.DAL.Attributes;
using GameStore.DAL.Repositories.Abstract;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStore.DAL.Repositories.Implementation
{
    public class NorthwindGenericRepository<TDocument> : INorthwindGenericRepository<TDocument> where TDocument : class
    {
        private readonly IMongoDatabase _db;
        private readonly IMongoCollection<TDocument> _collection;

        public NorthwindGenericRepository(IMongoClient client, IConfiguration _config)
        {
            _db = client.GetDatabase(_config.GetConnectionString("NorthwindDbName"));
            _collection = _db.GetCollection<TDocument>(GetCollectionName());
        }

        public async Task<TDocument> GetAsync(Expression<Func<TDocument, bool>> expression)
        {
            var cursor = await _collection.FindAsync(expression);
            return null;
        }

        public async Task<List<TDocument>> GetListAsync()
        {
            var cursor = await _collection.FindAsync(new BsonDocument());
            var result = await cursor.ToListAsync();

            return result;
        }

        public async Task<List<TDocument>> GetRangeAsync(List<Expression<Func<TDocument, bool>>> filters)
        {
            var filter = CreateFilters(filters);
            var cursor = await _collection.FindAsync(filter);
            var result = await cursor.ToListAsync();

            return result;
        }

        public async Task<int> GetCountAsync(List<Expression<Func<TDocument, bool>>> filters)
        {
            var filter = CreateFilters(filters);
            var cursor = await _collection.FindAsync(filter);
            var result = await cursor.ToListAsync();

            return result.Count();
        }

        private FilterDefinition<TDocument> CreateFilters(List<Expression<Func<TDocument,bool>>> filters)
        {
            var builder = Builders<TDocument>.Filter;
            var filter = builder.Empty;

            foreach(var item in filters)
            {
               filter &= builder.Where(item);
            }
          
            return filter;
        }

        private static string GetCollectionName()
        {
            return (typeof(TDocument).GetCustomAttributes(typeof(MongoCollectionAttribute), true).FirstOrDefault() as MongoCollectionAttribute)?.CollectionName;
        }

    }
}
