using System.ComponentModel.DataAnnotations.Schema;

namespace MainAPI.Models
{
    [NotMapped]
    public class Reading
    {
        public string? SensorId { get; set; }


        public string? SensorType { get; set; }


        public DateTime? ReadDate { get; set; }


        public string? Value { get; set; }
    }
}
