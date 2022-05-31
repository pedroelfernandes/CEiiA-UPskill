using WeatherStation.api.Models;

namespace WeatherStation.api.DTOs
{
    public class SensorDTO
    {
        public string Id { get; set; } = null!;


        public string Name { get; set; } = null!;


        public string Type { get; set; } = null!;


        public string Company { get; set; } = null!;


        public static SensorDTO ToDto(Sensor sensor)
        {
            return new SensorDTO()
            {
                Id = sensor.Id,
                Name = sensor.Name,
                Type = sensor.Type,
                Company = sensor.Company
            };
        }
    }
}
