using Application.Properties;
using Domain.Entities;
using Domain.Intefaces;

namespace Adapters.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _repository;

        public PropertyService(IPropertyRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Property>> GetPropertiesAsync(string? name, string? address, decimal? minPrice, decimal? maxPrice)
        {
            return await _repository.GetPropertiesAsync(name, address, minPrice, maxPrice);
        }

        public async Task<Property?> GetPropertyByIdAsync(string id)
        {
            return await _repository.GetPropertyByIdAsync(id);
        }

        public async Task CreateAsync(Property property)
        {
            await _repository.CreateAsync(property);
        }
    }
}
