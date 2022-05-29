using WeatherStation.api.Models;

namespace WeatherStation.api.DTOs
{
    //move to layer2 or create relatiship between sensor and readings and further improve data in sensor(startup date, last update date, etc)
    public class SensorDTO
    {
        public string Id { get; set; }


        public string Type { get; set; }


        public static SensorDTO ToDto(Reading reading)
        {
            return new SensorDTO()
            {
                Id = reading.SensorId,
                Type = reading.SensorType
            };
        }
    }
}
