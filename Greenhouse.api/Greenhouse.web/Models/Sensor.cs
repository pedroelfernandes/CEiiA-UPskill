using System.ComponentModel.DataAnnotations;

namespace Greenhouse.web.Models
{
    public class Sensor
    {
        
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Unit { get; set; }

        public string? Company { get; set; }

        public DataType ActiveSince { get; set; }

        public bool IsActive { get; set; }

        public int SensorTypeId { get; set; }
        public SensorType? SensorType { get; set; }

        public ICollection<AssetSensor>? Assets { get; set; }
    }
}

