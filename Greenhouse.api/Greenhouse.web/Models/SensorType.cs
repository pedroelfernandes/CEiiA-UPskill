using System.ComponentModel.DataAnnotations;

namespace Greenhouse.web.Models
{
    public class SensorType
    {
        public int Id {get; set;}

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool IsActive { get; set; }
    }
}