using Greenhouse.api.Enumerables;
using Greenhouse.api.Models;
using Greenhouse.api.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Greenhouse.api.Repositories.Implementations
{
    public class ReadingRepository : IReadingRepository
    {
        private readonly IMongoCollection<Reading> _readingsCollection;


        public ReadingRepository(IOptions<GreenhouseDatabaseSettings> options)
        {
            MongoClient mongoClient = new MongoClient(options.Value.ConnectionString);

            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);

            _readingsCollection = mongoDatabase.GetCollection<Reading>("Readings");
        }


        private async Task<IReadOnlyList<Reading>> GetLastXReadings(string sensorId, int size) =>
            await _readingsCollection.Find(r => r.SensorId == sensorId).Limit(size).SortByDescending(r => r.ReadDate).ToListAsync();


        private async Task<IReadOnlyList<Reading>> GetReadingsBetweenDates(string sensorId, DateTime startDate, DateTime endDate)
        {
            FilterDefinition<Reading> filter = new FilterDefinitionBuilder<Reading>().Where(r => r.ReadDate >= startDate && r.ReadDate <= endDate && r.SensorId == sensorId);

            return await _readingsCollection.Find(filter).SortByDescending(r => r.ReadDate).ToListAsync();
        }


        public async Task<IReadOnlyList<Reading>> GetBySensorId(string sensorId, int size, SortEnum sort, OrderEnum order)
        {
            IReadOnlyList<Reading> readings = await GetLastXReadings(sensorId, size);

            if (sort.Equals(SortEnum.Descending))
            {
                return order switch
                {
                    OrderEnum.Id => readings.OrderByDescending(r => r.Id).ToList(),
                    OrderEnum.ReadDate => readings.OrderByDescending(r => r.ReadDate).ToList(),
                    OrderEnum.Value => readings.OrderByDescending(r => r.Value).ToList(),
                    _ => throw new Exception("Check your enums.")
                };
            } 
            else
            {
                return order switch
                {
                    OrderEnum.Id => readings.OrderBy(r => r.Id).ToList(),
                    OrderEnum.ReadDate => readings.OrderBy(r => r.ReadDate).ToList(),
                    OrderEnum.Value => readings.OrderBy(r => r.Value).ToList(),
                    _ => throw new Exception("Check your enums.")
                };
            }
        }


        public async Task<IReadOnlyList<Reading>> GetBetweenDatesBySensorId(string sensorId, DateTime startDate, DateTime endDate, SortEnum sort, OrderEnum order)
        {
            IReadOnlyList<Reading> readings = await GetReadingsBetweenDates(sensorId, startDate, endDate);

            if (sort.Equals(SortEnum.Descending))
            {
                return order switch
                {
                    OrderEnum.Id => readings.OrderByDescending(r => r.Id).ToList(),
                    OrderEnum.ReadDate => readings.OrderByDescending(r => r.ReadDate).ToList(),
                    OrderEnum.Value => readings.OrderByDescending(r => r.Value).ToList(),
                    _ => throw new Exception("Check your enums.")
                };
            } 
            else
            {
                return order switch
                {
                    OrderEnum.Id => readings.OrderByDescending(r => r.Id).ToList(),
                    OrderEnum.ReadDate => readings.OrderByDescending(r => r.ReadDate).ToList(),
                    OrderEnum.Value => readings.OrderByDescending(r => r.Value).ToList(),
                    _ => throw new Exception("Check your enums.")
                };
            }
        }
    }
}
