using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using WeatherStation.api.Models;

namespace WeatherStation.api.Services
{
    public class WeatherStationService
    {
        private readonly IMongoCollection<Reading> _readingsCollection;

        public WeatherStationService(IOptions<WeatherStationDatabaseSettings> weatherStationDatabaseSettings)
        {
            var mongoClient = new MongoClient(weatherStationDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(weatherStationDatabaseSettings.Value.DatabaseName);

            _readingsCollection = mongoDatabase.GetCollection<Reading>(weatherStationDatabaseSettings.Value.Readings);
        }

        public async Task<List<Reading>> GetAsync() =>
            await _readingsCollection.Find(_ => true).ToListAsync();


        public List<Reading> GetLast()
        {
            var myList = _readingsCollection.AsQueryable().OrderByDescending(r => r.ReadDate).ToList().DistinctBy(r => r.SensorId).ToList();
            return myList;
        }
    }
}
