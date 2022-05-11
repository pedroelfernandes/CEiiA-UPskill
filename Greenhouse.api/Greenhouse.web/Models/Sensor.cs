using System.ComponentModel.DataAnnotations;

namespace Greenhouse.web.Models
{
    public class Sensor
    {
       
        public int SensorId { get; set; }

       
        public string SensorName { get; set; } = null!;


     
        public string SensorType { get; set; } = null!;

     
        public int ApiId { get; set; }

        //[Required]
        //[DataType(DataType.Url)]
        //public string ApiUrl { get; set; }


    }
}
