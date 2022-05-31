using WeatherStation.api.Models;

namespace WeatherStation.api.DTOs
{
    public class ReadingDTO
    {
        public string Id { get; set; } = null!;


        public DateTime ReadDate { get; set; }


        public string Value { get; set; } = null!;


        public static ReadingDTO ToDto(Reading reading)
        {
            return new ReadingDTO()
            {
                Id = reading.Id,
                ReadDate = reading.ReadDate,
                Value = reading.Value
            };
        }
    }
}
