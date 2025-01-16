using Domain.Entities;
using Domain.Intefaces;

namespace Application.Properties.UseCases
{
    public class GetPropertiesUseCase
    {
        private readonly IPropertyRepository _propertyRepository;

        public GetPropertiesUseCase(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<List<Property>> Execute()
        {
            return await _propertyRepository.GetAllAsync();
        }
    }
}
