using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson;

namespace Domain.Entities
{
    public class PropertyTrace
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string? IdPropertyTrace { get; set; }
        public DateTime? DateSale { get; set; }
        public string? Name { get; set; } = null;
        public decimal? Value { get; set; } = null;
        public string? Tax { get; set; } = null;
    }
}
