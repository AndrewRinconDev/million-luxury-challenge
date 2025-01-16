using Application.Properties.UseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly GetPropertiesUseCase _getAllUseCase;
        private readonly CreatePropertyUseCase _createPropertyUseCase;

        public PropertyController(GetPropertiesUseCase getAllUseCase, CreatePropertyUseCase createPropertyUseCase)
        {
            _getAllUseCase = getAllUseCase;
            _createPropertyUseCase = createPropertyUseCase;
        }

        [HttpGet(Name = "GetAllProperties")]
        public async Task<IActionResult> GetProperties([FromQuery] string? name, [FromQuery] string? address, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice)
        {
            var properties = await _getAllUseCase.Execute(name, address, minPrice, maxPrice);
            return Ok(properties);
        }

        [HttpGet]
        public async Task<IActionResult> GetProperties([FromQuery] string? name, [FromQuery] string? address, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice)
        {
            var properties = await _propertyService.GetPropertiesAsync(name, address, minPrice, maxPrice);
            return Ok(properties);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPropertyById(Guid id)
        {
            var property = await _propertyService.GetPropertyByIdAsync(id);
            if (property == null) return NotFound();
            return Ok(property);
        }

        [HttpPost(Name = "CreateProperty")]
        public async Task<IActionResult> Create([FromBody] Property property)
        {
            // Create property
            await _createPropertyUseCase.Execute(property);
            return CreatedAtRoute("GetAllProperties", null);
        }
    }
}
