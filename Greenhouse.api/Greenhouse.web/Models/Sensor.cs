using System.ComponentModel.DataAnnotations;

namespace Greenhouse.web.Models
{
    public class Sensor
    {
        [Key]
        public int? Id { get; set; } = 0;

        public string? IdInAPI { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Unit { get; set; }

        public int? URLId { get; set; }

        public string? Company { get; set; }

        public DateTime? ActiveSince { get; set; }

        public bool? IsActive { get; set; }

        public int? SensorTypeId { get; set; }
        public SensorType? SensorType { get; set; }

        public ICollection<AssetSensor>? Assets { get; set; }
    }
}

