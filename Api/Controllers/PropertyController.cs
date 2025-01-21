using Application.Properties;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetProperties([FromQuery] string? name, [FromQuery] string? address, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice)
        {
            try
            {
                var properties = await _propertyService.GetPropertiesAsync(name, address, minPrice, maxPrice);
                return Ok(properties);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPropertyById(string id)
        {
            try
            {
                var property = await _propertyService.GetPropertyByIdAsync(id);

                if (property == null) return NotFound();

                return Ok(property);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                return StatusCode(500);
            }
        }

        [HttpPost(Name = "CreateProperty")]
        public async Task<IActionResult> Create([FromBody] Property property)
        {
            try
            {
                await _propertyService.CreateAsync(property);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
