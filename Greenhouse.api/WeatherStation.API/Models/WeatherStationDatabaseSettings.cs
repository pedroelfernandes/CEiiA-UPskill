namespace WeatherStation.api.Models
{
    public class WeatherStationDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string Readings { get; set; } = null!;
    }
}
