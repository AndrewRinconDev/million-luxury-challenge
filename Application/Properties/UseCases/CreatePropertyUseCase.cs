using Domain.Entities;
using Domain.Intefaces;

namespace Application.Properties.UseCases
{
    public class CreatePropertyUseCase
    {
        private readonly IPropertyRepository _propertyRepository;

        public CreatePropertyUseCase(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task Execute(Property property)
        {
            await _propertyRepository.CreateAsync(property);
        }
    }
}
