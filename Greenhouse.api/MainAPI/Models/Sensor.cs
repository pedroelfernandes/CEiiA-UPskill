using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainAPI.Models
{
    public class Sensor
    {
        [Required, Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public string? Unit { get; set; }

        [Required]
        public int URLId { get; set; }

        [Required]
        public string? Company { get; set; }

        [Required]
        public DateTime ActiveSince { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required, ForeignKey("SensorType")]
        public int SensorTypeId { get; set; }
        public SensorType? SensorType { get; set; }

        public ICollection<AssetSensor>? Assets { get; set; }

    }
}
