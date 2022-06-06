using MainAPI.Models;

namespace MainAPI.DTO
{
    public class SensorTypeDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public bool Active { get; set; }

        public static SensorTypeDTO ToDto(SensorType sensorType)
        {
            return new SensorTypeDTO()
            {
                Id = sensorType.Id,
                Name = sensorType.Name,
                Description = sensorType.Description,
                Active = sensorType.Active,
            };
        }
    }
}
