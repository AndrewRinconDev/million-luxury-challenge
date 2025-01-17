using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Adapters.DBContexts
{
    public interface IDbContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }

    public class MongoDbContext : IDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IMongoDatabase database)
        {
            _database = database;
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            // Generic get the collection of the database
            return _database.GetCollection<T>(name);
        }
    }
}

