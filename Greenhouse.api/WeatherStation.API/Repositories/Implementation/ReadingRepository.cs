using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WeatherStation.api.Models;
using WeatherStation.api.Repositories.Interface;

namespace WeatherStation.api.Repositories.Implementation
{
    public class ReadingRepository : IReadingRepository
    {
        private readonly IMongoCollection<Reading> _readingsCollection;


        public ReadingRepository(IOptions<WeatherStationDatabaseSettings> options)
            : base()
        {
            MongoClient mongoClient = new MongoClient(options.Value.ConnectionString);

            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);

            _readingsCollection = mongoDatabase.GetCollection<Reading>("Readings");
        }


        public async Task<IReadOnlyList<Reading>> GetBySensorId(string sensorId, int size, string sort = "desc", string order = "date")
        {
            SortDefinition<Reading> sortDefinition = sort.Equals("desc", StringComparison.OrdinalIgnoreCase) ? 
                Builders<Reading>.Sort.Descending(order) : Builders<Reading>.Sort.Ascending(order);

            return await _readingsCollection.Find(r => r.SensorId == sensorId).Sort(sortDefinition).Limit(size).ToListAsync();
        }


        public async Task<IReadOnlyList<Reading>> GetBetweenDatesBySensorId(string sensorId, DateTime startDate, DateTime endDate, string sort = "desc", string order = "date")
        {
            SortDefinition<Reading> sortDefinition = sort.Equals("desc", StringComparison.OrdinalIgnoreCase) ?
                Builders<Reading>.Sort.Descending(order) : Builders<Reading>.Sort.Ascending(order);

            FilterDefinition<Reading> filter = new FilterDefinitionBuilder<Reading>().Where(r => r.ReadDate >= startDate && r.ReadDate <= endDate && r.SensorId == sensorId);

            return await _readingsCollection.Find(filter).Sort(sortDefinition).ToListAsync();
        }
    }
}
