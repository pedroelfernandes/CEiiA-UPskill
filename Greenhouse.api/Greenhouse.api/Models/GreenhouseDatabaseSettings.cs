namespace Greenhouse.api.Models
{
    public class GreenhouseDatabaseSettings
    {
        public const string Name = "GreenhouseDatabase";


        public string ConnectionString { get; set; } = null!;


        public string DatabaseName { get; set; } = null!;
    }
}
