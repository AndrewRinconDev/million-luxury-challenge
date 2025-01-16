using Domain.Entities;

namespace Domain.Intefaces
{
    public interface IPropertyRepository
    {
        Task<List<Property>> GetAllAsync();
        Task CreateAsync(Property property);
    }
}
