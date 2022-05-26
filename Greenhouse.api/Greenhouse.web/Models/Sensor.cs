using System.ComponentModel.DataAnnotations;

namespace Greenhouse.web.Models
{
    public class Sensor
    {
        public int Id { get; set; }


        public string SensorName { get; set; } = null!;


        public string Type { get; set; } = null!;


        public int ApiId { get; set; }
    }
}
