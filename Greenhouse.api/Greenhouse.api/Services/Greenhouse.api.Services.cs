using Greenhouse.api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Greenhouse.api.Services
{
    public class GreenhouseService
    {
        private readonly IMongoCollection<Reading> _readingsCollection;



        public GreenhouseService(
            IOptions<GreenhouseDatabaseSettings> greenhouseDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                greenhouseDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                greenhouseDatabaseSettings.Value.DatabaseName);

            _readingsCollection = mongoDatabase.GetCollection<Reading>(
                greenhouseDatabaseSettings.Value.ReadingsCollectionName);
        }



        public async Task<List<Reading>> GetAsync() =>
            await _readingsCollection.Find(_ => true).ToListAsync();



        public List<Reading> GetLast()
        {
            var myList = _readingsCollection.AsQueryable().OrderByDescending(r => r.ReadDate).ToList().DistinctBy(r => r.SensorId).ToList();
            return myList;

            //var sensorIdList = _readingsCollection.DistinctAsync(r => r.SensorId, FilterDefinition<Reading>.Empty);

            //await sensorIdList.ForEachAsync(sensorId => _readingsCollection.FindAsync(r => r.SensorId == sensorId).AsQueryable().OrderByDescending(r => r.ReadDate));            
        }



        public async Task<Reading> GetLastBySensorId(string id) =>
            await _readingsCollection.Find(r => r.SensorId == id).SortByDescending(r => r.ReadDate).FirstOrDefaultAsync();
    }
}
