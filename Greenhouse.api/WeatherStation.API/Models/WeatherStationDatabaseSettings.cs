namespace WeatherStation.api.Models
{
    public class WeatherStationDatabaseSettings
    {
        
        //this string helps with a better coesion of configuration injection and make's it less prone to human error 
        
        public const string Name = "WeatherStationDatabase";
        
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string Readings { get; set; } = null!;
    }
}
