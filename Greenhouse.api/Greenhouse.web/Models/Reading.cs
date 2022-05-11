namespace Greenhouse.web.Models
{
    public class Reading
    {
        public int ReadingId { get; set; }

        public string SensorId { get; set; } = null!;
       
        public DateTime ReadingDate { get; set; }

        public string ReadingUnit { get; set; } = null!;
    }
}
