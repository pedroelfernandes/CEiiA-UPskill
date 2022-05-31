using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WeatherStation.api.Models;
using WeatherStation.api.Repositories.Interface;

namespace WeatherStation.api.Repositories.Implementation
{
    public class SensorRepository : ISensorRepository
    {
        private readonly IMongoCollection<Sensor> _sensorsCollection;


        public SensorRepository(IOptions<WeatherStationDatabaseSettings> options)
        {
            MongoClient mongoClient = new MongoClient(options.Value.ConnectionString);

            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);

            _sensorsCollection = mongoDatabase.GetCollection<Sensor>("Sensors");
        }


        public async Task<Sensor> GetSensorById(string id) => 
            await _sensorsCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
    }
}
