using Domain.Entities;

namespace Application.Properties
{
    public interface IPropertyService
    {
        Task<List<Property>> GetPropertiesAsync(string? name, string? address, decimal? minPrice, decimal? maxPrice);
        Task<Property?> GetPropertyByIdAsync(string id);
        Task CreateAsync(Property property);
    }
}
