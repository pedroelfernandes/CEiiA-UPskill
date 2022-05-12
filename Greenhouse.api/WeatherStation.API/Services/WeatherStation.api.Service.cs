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

        public async Task<Reading> GetLastBySensorId(string id) =>
            await _readingsCollection.Find(r => r.SensorId == id).SortByDescending(r => r.ReadDate).FirstOrDefaultAsync();

        public async Task<List<Reading>> GetLastValuesBySensorId(string id, int limit) =>
            await _readingsCollection.Find(r => r.SensorId == id).SortByDescending(r => r.ReadDate).Limit(limit).ToListAsync();
    }
}
