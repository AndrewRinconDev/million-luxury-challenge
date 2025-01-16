using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson;

namespace Domain.Entities
{
    public class PropertyImage
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string? IdPropertyImage { get; set; }
        public string? File { get; set; }
        public bool? Enable { get; set; } = false;
    }
}
