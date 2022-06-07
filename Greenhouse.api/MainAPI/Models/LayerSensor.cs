namespace MainAPI.Models
{
    public class LayerSensor
    {
        public string Id { get; set; } = null!;


        public string Name { get; set; } = null!;


        public string Type { get; set; } = null!;


        public string Company { get; set; } = null!;


        public DateTime ActivationDate { get; set; }
    }
}
