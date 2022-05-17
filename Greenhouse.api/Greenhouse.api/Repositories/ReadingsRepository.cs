﻿using Greenhouse.api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Greenhouse.api.Repositories
{
    public class ReadingsRepository
    {
        private readonly IMongoCollection<Reading> _readingsCollection;

        public ReadingsRepository(IOptions<GreenhouseDatabaseSettings> greenhouseDatabaseSettings)
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
        }



        public async Task<Reading> GetLastBySensorId(string id) =>
            await _readingsCollection.Find(r => r.SensorId == id).SortByDescending(r => r.ReadDate).FirstOrDefaultAsync();



        public async Task<List<Reading>> GetLastValuesBySensorId(string id, int limit) =>
            await _readingsCollection.Find(r => r.SensorId == id).SortByDescending(r => r.ReadDate).Limit(limit).ToListAsync();
    }
}