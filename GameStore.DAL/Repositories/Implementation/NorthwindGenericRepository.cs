using GameStore.DAL.Attributes;
using GameStore.DAL.Entities;
using GameStore.DAL.Repositories.Abstract;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStore.DAL.Repositories.Implementation
{
    public class NorthwindGenericRepository<TDocument> : INorthwindGenericRepository<TDocument> where TDocument : BaseEntity
    {
        private readonly IMongoDatabase _db;
        private readonly IMongoCollection<TDocument> _collection;
        private readonly IMongoQueryable<TDocument> _dbSet;

        public NorthwindGenericRepository(IMongoClient client, IConfiguration _config)
        {
            _db = client.GetDatabase(_config.GetConnectionString("NorthwindDbName"));
            _collection = _db.GetCollection<TDocument>(GetCollectionName());
            _dbSet = _collection.AsQueryable();
        }

        public async Task<TDocument> GetAsync(Expression<Func<TDocument, bool>> expression)
        {
          
            var result = await _dbSet.FirstOrDefaultAsync(expression);
            return result;
        }

        public async Task<List<TDocument>> GetListAsync()
        {
            
            var result = await _dbSet.ToListAsync();

            return result;
        }

        public async Task<List<TDocument>> GetRangeAsync(List<Expression<Func<TDocument, bool>>> filters)
        {
            var query = GetQuery(filters);

            var result = await query.ToListAsync();

            return result;
        }

        public async Task<int> GetCountAsync(List<Expression<Func<TDocument, bool>>> filters)
        {
            var query = GetQuery(filters);
            int res = await query.CountAsync();
            
            return res;
        }

        private IMongoQueryable<TDocument> GetQuery(List<Expression<Func<TDocument, bool>>> filters)
        {
            IMongoQueryable<TDocument> query = _dbSet;

            foreach (var item in filters)
            {
                query = query.Where(item);
            }

            return query;
        }

        private FilterDefinition<TDocument> CreateFilters(List<Expression<Func<TDocument, bool>>> filters)
        {
            var builder = Builders<TDocument>.Filter;
            var filter = builder.Empty;

            foreach (var item in filters)
            {
                filter &= builder.Where(item);
            }

            return filter;
        }

        private static string GetCollectionName()
        {
            return (typeof(TDocument).GetCustomAttributes(typeof(MongoCollectionAttribute), true).FirstOrDefault() as MongoCollectionAttribute)?.CollectionName;
        }

        public async Task UpdateAsync(TDocument entityToUpdate)
        {
            var filter = Builders<TDocument>.Filter.Eq(o => o.ObjectId, entityToUpdate.ObjectId);
            var list = GetFields(entityToUpdate);
            var update = Builders<TDocument>.Update.Combine(list);
            var result = await _collection.UpdateOneAsync(x => x.ObjectId == entityToUpdate.ObjectId, update);
        }

        private List<UpdateDefinition<TDocument>> GetFields(TDocument document)
        {
            var type = document.GetType();
            List<UpdateDefinition<TDocument>> list = new List<UpdateDefinition<TDocument>>();
            foreach (var t in type.GetProperties())
            {
                var propName = t.Name;
                var isIgnore = t.GetCustomAttributes(typeof(BsonIgnoreAttribute),true).FirstOrDefault() as BsonIgnoreAttribute;
            
                if (isIgnore == null)
                {
                    var propValue = t.GetValue(document);
                    list.Add(Builders<TDocument>.Update.Set(propName, propValue));
                } 
            }
            return list;
        }
    }
}
