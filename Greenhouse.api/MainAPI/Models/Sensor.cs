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

        public string? Unit { get; set; }

        [Required]
        public int URLId { get; set; }

        public string? Company { get; set; }

        [Required]
        public DataType ActiveSince { get; set; }

        [Required, ForeignKey("SensorType")]
        public SensorType? SensorType { get; set; }

        [Required, ForeignKey("Asset")]
        public Asset? Asset { get; set; }

    }
}
