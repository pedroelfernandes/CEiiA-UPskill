using System.ComponentModel.DataAnnotations;

namespace Greenhouse.web.Models
{
    public class SensorType
    {

        public int IdSensorType {get; set;}

        public string NameSensorType { get; set; } = null!;

        public string SensorTypeDescription { get; set; } = null!;
    }
}
