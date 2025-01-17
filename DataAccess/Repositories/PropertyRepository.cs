using Adapters.DBContexts;
using Domain.Entities;
using Domain.Intefaces;
using MongoDB.Driver;

namespace Adapters.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly IMongoCollection<Property> _propertiesCollection;

        public PropertyRepository(IDbContext context)
        {
            // Get the collection of context
            _propertiesCollection = context.GetCollection<Property>("properties");
        }

        public async Task<List<Property>> GetPropertiesAsync(string? name, string? address, decimal? minPrice, decimal? maxPrice)
        {
            var filter = Builders<Property>.Filter.Empty;

            // Add filters
            if (!string.IsNullOrEmpty(name))
                filter &= Builders<Property>.Filter.Regex("Name", new MongoDB.Bson.BsonRegularExpression(name, "i"));
            if (!string.IsNullOrEmpty(address))
                filter &= Builders<Property>.Filter.Regex("Address", new MongoDB.Bson.BsonRegularExpression(address, "i"));
            if (minPrice.HasValue)
                filter &= Builders<Property>.Filter.Gte(p => p.Price, minPrice.Value);
            if (maxPrice.HasValue)
                filter &= Builders<Property>.Filter.Lte(p => p.Price, maxPrice.Value);

            // Return all properties that match the filter
            return await _propertiesCollection.Find(filter).ToListAsync();
        }

        public async Task<Property?> GetPropertyByIdAsync(string id)
        {
            var propertyFound = _propertiesCollection.Find(p => p.IdProperty == id);
            
            // Return null if property not found
            if (propertyFound == null)
                return null;

            return await propertyFound.FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Property property)
        {
            await _propertiesCollection.InsertOneAsync(property);
        }
    }
}
