using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Greenhouse.api.Models
{
    public class Sensor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;


        public string Name { get; set; } = null!;


        public string Type { get; set; } = null!;


        public string Company { get; set; } = null!;


        [BsonElement("Date")]
        public DateTime ActivationDate { get; set; }
    }
}
