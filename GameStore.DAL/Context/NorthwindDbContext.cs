using GameStore.DAL.Entities;
using GameStore.DAL.Static;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace GameStore.DAL.Context
{
    public class NorthwindDbContext
    {
        private readonly IMongoDatabase _database;

        private const string NorthwindDbName = "Northwind";

        public NorthwindDbContext()
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile(Constants.JsonConfigFile, false).Build();

            string connectionString = config.GetConnectionString(Constants.NorthwindDb);

            MongoClient client = new MongoClient(connectionString);

            _database = client.GetDatabase(NorthwindDbName);
        }

        public List<BsonDocument> GetAsync()
        {
           
            return null;
        }

    }
}
