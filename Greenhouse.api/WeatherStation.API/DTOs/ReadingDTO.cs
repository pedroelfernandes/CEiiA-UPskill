using WeatherStation.api.Models;

namespace WeatherStation.api.DTOs
{
    public class ReadingDTO
    {
        public string SensorId { get; set; }


        public string SensorType { get; set; }


        public DateTime ReadDate { get; set; }


        public string Value { get; set; }


        public static ReadingDTO ToDto(Reading reading)
        {
            return new ReadingDTO()
            {
                SensorId = reading.SensorId,
                SensorType = reading.SensorType,
                ReadDate = reading.ReadDate,
                Value = reading.Value
            };
        }
    }
}
