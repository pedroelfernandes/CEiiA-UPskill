﻿using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WeatherStation.api.Models;

namespace WeatherStation.api.Repositories
{
    public class ReadingRepository
    {
        private readonly IMongoCollection<Reading> _readingsCollection;


        public ReadingRepository(IOptions<WeatherStationDatabaseSettings> options)
        {
            MongoClient mongoClient = new MongoClient(options.Value.ConnectionString);

            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);

            _readingsCollection = mongoDatabase.GetCollection<Reading>(options.Value.Readings);
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


        public List<string> GetSensorsId() =>
            _readingsCollection.Distinct(r => r.SensorId, FilterDefinition<Reading>.Empty).ToList();


        public List<Reading> GetSensors()
        {
            List<string> sensors = GetSensorsId();

            if (sensors is null)
                throw new Exception("Sensors not found");

            List<Reading> readings = new List<Reading>();

            foreach (string sensorId in sensors)
            {
                readings.Add(_readingsCollection.Find(r => r.SensorId == sensorId).SortByDescending(r => r.ReadDate).FirstOrDefault());
            }

            return readings;
        }
    }
}