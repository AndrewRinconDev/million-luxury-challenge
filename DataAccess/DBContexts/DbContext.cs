using MongoDB.Driver;

namespace DataAccess.DBContexts
{
    public class DbContext
    {
        private readonly IMongoDatabase _database;

        public DbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoDatabase GetDatabase() => _database;
    }
}
