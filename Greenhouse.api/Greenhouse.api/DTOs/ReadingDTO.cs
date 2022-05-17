using Greenhouse.api.Models;

namespace Greenhouse.api.DTOs
{
    public class ReadingDTO
    {
        public string? SensorId { get; init; }


        public string? SensorType { get; init; }


        public DateTime? ReadDate { get; init; }


        public string? Value { get; init; }



        public static ReadingDTO ToDto(Reading reading)
        {
            return new ReadingDTO
            {
                SensorId = reading.SensorId,
                SensorType = reading.SensorType,
                ReadDate = reading.ReadDate,
                Value = reading.Value
            };
        }
    }
}
