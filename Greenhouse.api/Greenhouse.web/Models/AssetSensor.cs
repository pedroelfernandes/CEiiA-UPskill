namespace Greenhouse.web.Models
{
    public class AssetSensor
    {
        public int AssetId { get; set; }
        public int SensorId { get; set; }
        public Asset? Asset { get; set; }
        public Sensor? Sensor { get; set; }
    }
}
