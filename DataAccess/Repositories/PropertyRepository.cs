using Domain.Entities;
using Domain.Intefaces;
using MongoDB.Driver;

namespace DataAccess.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly IMongoCollection<Property> _propertiesCollection;

        public PropertyRepository(IMongoDatabase database)
        {
            _propertiesCollection = database.GetCollection<Property>("properties");
        }

        public async Task<List<Property>> GetAllAsync()
        {
            return await _propertiesCollection.Find(_ => true).ToListAsync();
        }

        public Task CreateAsync(Property property)
        {
            return _propertiesCollection.InsertOneAsync(property);
        }
    }
}
