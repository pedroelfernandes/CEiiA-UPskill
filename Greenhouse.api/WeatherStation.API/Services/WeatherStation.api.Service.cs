using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using WeatherStation.api.DTO;
using WeatherStation.api.Models;
using WeatherStation.api.Repositories;

namespace WeatherStation.api.Services
{
    public class WeatherStationService
    {
        //private readonly IMongoCollection<Reading> _readingsCollection;
        private readonly ReadingRepository _readingRepository;


        public WeatherStationService(IOptions<WeatherStationDatabaseSettings> options)
        {
            _readingRepository = new ReadingRepository(options);
        }

        public async Task<List<Reading>> GetAsync() =>
            //await _readingsCollection.Find(_ => true).ToListAsync();
            await _readingRepository.GetAsync();


        public List<ReadingDTO> GetLast()
        {
            //var myList = _readingsCollection.AsQueryable().OrderByDescending(r => r.ReadDate).ToList().DistinctBy(r => r.SensorId).ToList();
            //return myList;

            List<Reading> readings = _readingRepository.GetLast();
            if (readings is null)
                throw new Exception("Readings not found");

            List<ReadingDTO> result = readings.Select(reading => ReadingDTO.ToDto(reading)).ToList();
            return result;
        }

        public async Task<ReadingDTO> GetLastBySensorId(string id)
        {
            //await _readingsCollection.Find(r => r.SensorId == id).SortByDescending(r => r.ReadDate).FirstOrDefaultAsync();

            Reading reading = await _readingRepository.GetLastBySensorId(id);
            if (reading is null)
                throw new Exception("Reading not found");

            ReadingDTO result = ReadingDTO.ToDto(reading);
            return result;
        }


        public async Task<List<ReadingDTO>> GetLastValuesBySensorId(string id, int limit)
        {
            //await _readingsCollection.Find(r => r.SensorId == id).SortByDescending(r => r.ReadDate).Limit(limit).ToListAsync();

            IEnumerable<Reading> readings = await _readingRepository.GetLastValuesBySensorId(id, limit);
            if (readings is null)
                throw new Exception("Readings not found");

            List<ReadingDTO> result = readings.Select(r => ReadingDTO.ToDto(r)).ToList();
            return result;
        }
    }
}
