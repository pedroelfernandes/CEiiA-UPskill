using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WeatherStation.api.Models
{
    public class Reading
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string SensorId { get; set; }

        public string SensorType { get; set; }


        [BsonElement("Date")]
        public DateTime ReadDate { get; set; }

        public string Value { get; set; }
    }
}

