using System.ComponentModel.DataAnnotations;

namespace Greenhouse.web.Models
{
    public class SensorType
    {
        [Required]
        [Key]
        public int IdSensorType {get; set;}

        [Required]
        public string NameSensorType { get; set; } = null!;

        public string SensorTypeDescription { get; set; } = null!;
    }
}
