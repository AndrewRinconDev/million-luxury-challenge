using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Domain.Entities
{
    public class Property
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string? IdProperty { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; } = null;
        public decimal? Price { get; set; } = null;
        public string? CodeInternational { get; set; } = null;
        public int? year { get; set; } = null;
        public Owner? owner { get; set; } = null;
        public List<PropertyImage>? propertyImages { get; set; } = null;
        public List<PropertyTrace>? propertyTraces { get; set; } = null;
    }
}
