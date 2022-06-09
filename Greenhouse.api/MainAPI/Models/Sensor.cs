using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainAPI.Models
{
    public class Sensor
    {
        [Required, Key]
        public int Id { get; set; }


        [Required]
        public string? IdInAPI { get; set; }


        [Required]
        public string? Name { get; set; }


        public string? Description { get; set; }


        public string? Unit { get; set; }


        [Required]
        public int? URLId { get; set; }


        [Required]
        public string? Company { get; set; }


        [Required]
        public DateTime ActiveSince { get; set; } = DateTime.Now;


        [Required]
        public bool IsActive { get; set; } = true;


        [Required, ForeignKey("SensorType")]
        public int SensorTypeId { get; set; } = 1;


        public SensorType? SensorType { get; set; }


        public ICollection<AssetSensor>? Assets { get; set; }

        
        public static Sensor ToSensor(LayerSensor layerSensor)
        {
            return new()
            {
                IdInAPI = layerSensor.Id,
                Name = layerSensor.Name,
                Company = layerSensor.Company
            };
        }
    }
}
