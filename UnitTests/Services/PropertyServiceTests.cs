using Adapters.Services;
using Application.Properties;
using Domain.Entities;
using Domain.Intefaces;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace UnitTests.Services;

[TestFixture]
public class PropertyServiceTests
{
    private Mock<IPropertyRepository> _mockRepository;
    private IPropertyService _service;

    [SetUp]
    public void SetUp()
    {
        _mockRepository = new Mock<IPropertyRepository>();
        _service = new PropertyService(_mockRepository.Object);
    }

    [Test]
    public async Task GetPropertiesAsync_ShouldReturnFilteredProperties()
    {
        // Arrange
        var name = "House";
        var address = "Principal Street";
        var minPrice = 100000;
        var maxPrice = 200000;

        var mockProperties = new List<Property>
        {
            new Property { IdProperty = "1234", Name = "Beautiful House", Price = 150000 },
            new Property { IdProperty = "4567", Name = "Modern Apartment", Price = 300000 }
        };

        var mockPropertiesFiltered = mockProperties.FindAll(p => p.Price >= 100000 && p.Price <= 200000 && p.Name.Contains(name));
        _mockRepository.Setup(repo => repo.GetPropertiesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal?>(), It.IsAny<decimal?>()))
            .ReturnsAsync(mockPropertiesFiltered);

        // Act
        var result = await _service.GetPropertiesAsync(name, null, minPrice, maxPrice);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count(), Is.EqualTo(1));
    }


    [Test]
    public async Task GetPropertiesAsync_ShouldReturnAllProperties()
    {
        // Arrange
        var mockProperties = new List<Property>
        {
            new Property { IdProperty = "1234", Name = "Beautiful House", Price = 150000 },
            new Property { IdProperty = "4567", Name = "Modern Apartment", Price = 300000 }
        };
        _mockRepository.Setup(repo => repo.GetPropertiesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal?>(), It.IsAny<decimal?>()))
            .ReturnsAsync(mockProperties);

        // Act
        var result = await _service.GetPropertiesAsync(null, null, null, null);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count(), Is.EqualTo(2));
    }

    [Test]
    public async Task GetPropertyByIdAsync_ShouldReturnCorrectProperty()
    {
        // Arrange
        var propertyId = "1234";
        var mockProperty = new Property { IdProperty = propertyId, Name = "Unique House", Price = 250000 };
        _mockRepository.Setup(repo => repo.GetPropertyByIdAsync(propertyId))
            .ReturnsAsync(mockProperty);

        // Act
        var result = await _service.GetPropertyByIdAsync(propertyId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result?.IdProperty, Is.EqualTo(propertyId));
    }

    [Test]
    public async Task CreateAsync_ShouldCreateProperty()
    {
        // Arrange
        var property = new Property { IdProperty = "1234", Name = "Beautiful House", Price = 150000 };
        _mockRepository.Setup(repo => repo.CreateAsync(property))
            .Returns(Task.CompletedTask);

        // Act
        await _service.CreateAsync(property);

        // Assert
        _mockRepository.Verify(repo => repo.CreateAsync(property), Times.Once);
    }
}