using System.ComponentModel.DataAnnotations;

namespace Greenhouse.web.Models
{
    public class Sensor
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string SensorName { get; set; } = null!;


        [Required]
        public string Type { get; set; } = null!;

        [Required]
        public int ApiId { get; set; }

        //[Required]
        //[DataType(DataType.Url)]
        //public string ApiUrl { get; set; }
    }
}
