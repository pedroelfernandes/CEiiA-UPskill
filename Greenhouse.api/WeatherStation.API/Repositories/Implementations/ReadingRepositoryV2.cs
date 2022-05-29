using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WeatherStation.api.Models;
using WeatherStation.api.Repositories.Interfaces;

namespace WeatherStation.api.Repositories
{
    public class ReadingRepositoryV2 : IReadingRepository
    {
        private readonly IMongoCollection<Reading> _readingsCollection;

        public ReadingRepositoryV2(IOptions<WeatherStationDatabaseSettings> options)
        {
            MongoClient mongoClient = new(options.Value.ConnectionString);

            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);

            _readingsCollection = mongoDatabase.GetCollection<Reading>(options.Value.Readings);
        }

        //with this you can easly send diferent sorting and ordering options
        //
        public async Task<IReadOnlyList<Reading>> GetAllBySensorIdAsync(string id, string sort, int size, string order)
        {
            order = order is null ? "id" : order;
            
            SortDefinition<Reading> sortDefinition = sort.Equals("desc", StringComparison.OrdinalIgnoreCase)
                ? Builders<Reading>.Sort.Descending(order) : Builders<Reading>.Sort.Ascending(order);
            
            return await _readingsCollection.Find(r => r.SensorId == id).Sort(sortDefinition).Limit(size).ToListAsync();
        }

        //in here you send a list of sensor ids from an asset to query db for theyr details
        public async Task<IReadOnlyList<Reading>> GetSensorDetailsByIdListAsync(List<string> ids, string sort, string order = "id")
        {
            SortDefinition<Reading> sortDefinition = sort.Equals("desc", StringComparison.OrdinalIgnoreCase)
                ? Builders<Reading>.Sort.Descending(order) : Builders<Reading>.Sort.Ascending(order);

            return await _readingsCollection.Find(r => ids.Contains(r.SensorId)).Sort(sortDefinition).ToListAsync();
        }

        public Task<Reading> CreateAsync(Reading reading)
        {
            throw new NotImplementedException();
        }

        public Task<Reading> UpdateAsync(Reading reading)
        {
            throw new NotImplementedException();
        }

        public async Task<DeleteResult> DeleteAsync(string id) => await _readingsCollection.DeleteOneAsync(r => r.Id == id);
        

        public async Task<Reading> GetReadingById(string id) => await _readingsCollection.FindAsync(r => r.Id == id).Result.FirstOrDefaultAsync();
    }
}
