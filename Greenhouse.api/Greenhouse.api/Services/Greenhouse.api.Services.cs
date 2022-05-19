using Greenhouse.api.DTOs;
using Greenhouse.api.Models;
using Greenhouse.api.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Greenhouse.api.Services
{
    public class GreenhouseService
    {
        //private readonly IMongoCollection<Reading> _readingsCollection;
        private readonly ReadingsRepository _readingsRepository;


        public GreenhouseService(IOptions<GreenhouseDatabaseSettings> options)
        {
            _readingsRepository = new ReadingsRepository(options);
        }


        public async Task<List<Reading>> GetAsync() =>
            //await _readingsCollection.Find(_ => true).ToListAsync();
            await _readingsRepository.GetAsync();


        public List<ReadingDTO> GetLast()
        {
            //var myList = _readingsCollection.AsQueryable().OrderByDescending(r => r.ReadDate).ToList().DistinctBy(r => r.SensorId).ToList();
            //return myList;            

            IEnumerable<Reading> readings = _readingsRepository.GetLast();
            if (readings is null)
            {
                throw new Exception("No readings found");
            }
            List<ReadingDTO> result = readings.Select(reading => ReadingDTO.ToDto(reading)).ToList();
            return result;
        }


        public async Task<ReadingDTO> GetLastBySensorId(string id)
        {
            //await _readingsCollection.Find(r => r.SensorId == id).SortByDescending(r => r.ReadDate).FirstOrDefaultAsync();

            Reading reading = await _readingsRepository.GetLastBySensorId(id);
            if (reading is null)
                throw new Exception("No reading found");

            return ReadingDTO.ToDto(reading);
        }


        public async Task<List<ReadingDTO>> GetLastValuesBySensorId(string id, int limit)
        {
            //await _readingsCollection.Find(r => r.SensorId == id).SortByDescending(r => r.ReadDate).Limit(limit).ToListAsync();

            IEnumerable<Reading> readings = await _readingsRepository.GetLastValuesBySensorId(id, limit);
            if (readings is null)
                throw new Exception("No readings found");

            List<ReadingDTO> result = readings.Select(reading => ReadingDTO.ToDto(reading)).ToList();
            return result;
        }


        //public List<string> GetSensorsId()
        //{
        //    IEnumerable<string> readings = _readingsRepository.GetSensorsId();
        //    if (readings is null)
        //        throw new Exception("No sensors found");

        //    return readings.ToList();
        //}


        public List<SensorDTO> GetSensors()
        {
            IEnumerable<Reading> readings = _readingsRepository.GetSensors();

            if (readings is null)
                throw new Exception("Readings not found");

            List<SensorDTO> result = readings.Select(reading => SensorDTO.ToDto(reading)).ToList();
            return result;
        }
    }
}
