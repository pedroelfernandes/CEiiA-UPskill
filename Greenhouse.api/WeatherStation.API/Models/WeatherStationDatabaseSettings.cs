namespace WeatherStation.api.Models
{
    public class WeatherStationDatabaseSettings
    {
        public const string Name = "WeatherStationDatabase";


        public string ConnectionString { get; set; } = null!;


        public string DatabaseName { get; set; } = null!;
    }
}
