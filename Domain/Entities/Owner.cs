using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson;

namespace Domain.Entities
{
    public class Owner
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string? IdOwner { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; } = null;
        public string? Photo { get; set; } = null;
        public DateTime? Birthday { get; set; } = null;
    }
}
