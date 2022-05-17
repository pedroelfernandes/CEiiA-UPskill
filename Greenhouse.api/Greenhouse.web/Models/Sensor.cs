using System.ComponentModel.DataAnnotations;

namespace Greenhouse.web.Models
{
    public class Sensor
    {
       [Required]
        [Key]
        public int SensorId { get; set; }

       [Required]
        public string SensorName { get; set; } = null!;


     [Required]
        public string SensorType { get; set; } = null!;

     [Required]
        public int ApiId { get; set; }

        //[Required]
        //[DataType(DataType.Url)]
        //public string ApiUrl { get; set; }
    }
}
