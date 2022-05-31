using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Greenhouse.api.Models
{
    public class Reading
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;


        public string SensorId { get; set; } = null!;


        [BsonElement("Date")]
        public DateTime ReadDate { get; set; }


        public string Value { get; set; } = null!;
    }
}
