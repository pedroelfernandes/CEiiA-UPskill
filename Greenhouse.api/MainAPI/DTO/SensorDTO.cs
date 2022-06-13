using MainAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace MainAPI.DTO
{
    public class SensorDTO
    {
        public int Id { get; set; }


        public string? Name { get; set; }


        public string? Description { get; set; }


        public string? Unit { get; set; }


        public string? Company { get; set; }


        public DateTime ActiveSince { get; set; }


        public bool IsActive { get; set; }
        
        
        public int SensorTypeId { get; set; }
        public SensorTypeDTO? SensorType { get; set; }


        public static SensorDTO ToDto(Sensor sensor)
        {
            return new SensorDTO()
            {
                Id = sensor.Id,
                Name = sensor.Name,
                Description = sensor.Description,
                Unit = sensor.Unit,
                Company = sensor.Company,
                ActiveSince = sensor.ActiveSince,
                IsActive = sensor.IsActive,
                SensorTypeId = sensor.SensorTypeId
            };
        }
    }
}
