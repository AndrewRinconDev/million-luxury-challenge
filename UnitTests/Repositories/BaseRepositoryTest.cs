using Adapters.DBContexts;
using Adapters.Repositories;
using Domain.Entities;
using Domain.Intefaces;
using Mongo2Go;
using MongoDB.Driver;
using Moq;

namespace UnitTests.Repositories
{
    public abstract class BaseRepositoryTest
    {
        private Mock<IDbContext> _mockContext;
        protected IMongoDatabase _database;
        protected MongoDbRunner _mongoRunner;
        protected readonly Mock<IMongoCollection<Property>> _mockCollection;
        protected readonly IPropertyRepository _repository;

        protected BaseRepositoryTest()
        {
            // Set up collection
            _mockCollection = new Mock<IMongoCollection<Property>>();

            _mockContext = new Mock<IDbContext>();
            _mockContext.Setup(context => context.GetCollection<Property>("properties"))
                .Returns(_mockCollection.Object);

            _repository = new PropertyRepository(_mockCollection.Object);
        }

    }
}
