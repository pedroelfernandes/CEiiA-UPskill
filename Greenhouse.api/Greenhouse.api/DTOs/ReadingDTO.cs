using Greenhouse.api.Models;

namespace Greenhouse.api.DTOs
{
    public class ReadingDTO
    {
        public string Id { get; init; } = null!;


        public string SensorId { get; set; } = null!;


        public DateTime ReadDate { get; init; }


        public string Value { get; init; } = null!;



        public static ReadingDTO ToDto(Reading reading)
        {
            return new ReadingDTO()
            {
                Id = reading.Id,
                SensorId = reading.SensorId,
                ReadDate = reading.ReadDate,
                Value = reading.Value
            };
        }
    }
}
