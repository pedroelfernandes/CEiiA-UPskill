using Greenhouse.api.Models;

namespace Greenhouse.api.DTOs
{
    public class SensorDTO
    {
        public string? Id { get; set; }


        public string? Type { get; set; }


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
