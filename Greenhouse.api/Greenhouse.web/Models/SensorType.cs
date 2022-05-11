using System.ComponentModel.DataAnnotations;

namespace Greenhouse.web.Models
{
    public class SensorType
    {
        [Required]
        [Key]
        public int IdSensorType {get; set;}

        [Required, StringLength(50)]
        public string NameSensorType { get; set; } = string.Empty;

        [Required, StringLength (50)]
        public string SensorTypeDescription { get; set; } = null!;
    }
}
