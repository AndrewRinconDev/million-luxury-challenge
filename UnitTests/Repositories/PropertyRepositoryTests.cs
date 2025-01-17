using Adapters.DBContexts;
using Adapters.Repositories;
using Domain.Entities;
using Mongo2Go;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Assert = NUnit.Framework.Assert;

namespace UnitTests.Repositories
{
    [TestFixture]
    public class PropertyRepositoryTests : BaseRepositoryTest
    {
        [SetUp]
        public void SetUp()
        {
            // Start an in-memory MongoDB instance
            _mongoRunner = MongoDbRunner.Start();
            var client = new MongoClient(_mongoRunner.ConnectionString);
            _database = client.GetDatabase("TestDatabase");
        }

        [TearDown]
        public void TearDown()
        {
            // Stop the MongoDB instance
            _mongoRunner.Dispose();
        }

        [Test]
        public async Task Test_Repository_Method()
        {
            // Arrange
            var property = new Property
            {
                IdProperty = "1234",
                Name = "Property 1",
                Address = "Principal Street",
                Price = 200000
            };

            // Act
            await _repository.CreateAsync(property);

            // Assert
            _mockCollection.Verify(collection => collection.InsertOneAsync(property, null, default), Times.Once);
        }

        [Test]
        public async Task Test_Repository_Method_With_Null_Property_Id()
        {
            // Arrange
            var property = new Property
            {
                Name = "Property 1",
                Address = "Principal Street",
                Price = 200000
            };

            // Act
            await _repository.CreateAsync(property);

            // Assert
            _mockCollection.Verify(collection => collection.InsertOneAsync(property, null, default), Times.Once);
        }

        [Test]
        public async Task GetPropertiesAsync_ShouldReturnAllProperties()
        {
            // Arrange
            var mockProperties = new List<Property>
            {
                new Property { IdProperty = "67898fc11c4a87d0d8ee8162", Name = "Beautiful House", Price = 150000 },
                new Property { IdProperty = "67898fc11c4a87d0d8ee8144", Name = "Modern Apartment", Price = 300000 }
            };
            var collection = _database.GetCollection<Property>("properties");

            // Insert test data
            collection.InsertMany(mockProperties);

            // Instantiate the repository with the actual collection
            var repository = new PropertyRepository(new MongoDbContext(_database));

            // Act
            var result = await repository.GetPropertiesAsync(null, null, null, null);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task GetPropertiesAsync_ShouldReturnFilteredProperties()
        {
            // Arrange
            var mockProperties = new List<Property>
            {
                new Property { IdProperty = "67898fc11c4a87d0d8ee8162", Name = "Beautiful House", Price = 150000 },
                new Property { IdProperty = "67898fc11c4a87d0d8ee8144", Name = "Modern Apartment", Price = 300000 }
            };
            var collection = _database.GetCollection<Property>("properties");

            // Insert test data
            collection.InsertMany(mockProperties);

            var repository = new PropertyRepository(new MongoDbContext(_database));

            // Act
            var result = await repository.GetPropertiesAsync("House", null, 100000, 200000);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Name, Is.EqualTo("Beautiful House"));
        }

        [Test]
        public async Task GetPropertyByIdAsync_ShouldReturnCorrectProperty()
        {
            // Arrange
            var testProperty = new Property
            {
                IdProperty = "67898fc11c4a87d0d8ee8161",
                Name = "Test Property 1",
                Address = "Principal Street",
                Price = 200000
            };

            var collection = _database.GetCollection<Property>("properties");

            // Insert test data
            collection.InsertOne(testProperty);


            // Instantiate the repository with the actual collection
            var repository = new PropertyRepository(new MongoDbContext(_database));

            // Act
            var result = await repository.GetPropertyByIdAsync("67898fc11c4a87d0d8ee8161");

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.IdProperty, Is.EqualTo("67898fc11c4a87d0d8ee8161"));
            Assert.That(result.Name, Is.EqualTo("Test Property 1"));
        }

        [Test]
        public async Task GetPropertyByIdAsync_ShouldReturnNull()
        {
            // Arrange
            var testProperty = new Property
            {
                IdProperty = "67898fc11c4a87d0d8ee8161",
                Name = "Test Property 1",
                Address = "Principal Street",
                Price = 200000
            };

            var collection = _database.GetCollection<Property>("properties");

            // Insert test data
            collection.InsertOne(testProperty);

            // Instantiate the repository with the actual collection
            var repository = new PropertyRepository(new MongoDbContext(_database));

            // Act
            var result = await repository.GetPropertyByIdAsync("67898fc11c4a87d0d8ee8162");

            // Assert
            Assert.That(result, Is.Null);
        }
    }
}
