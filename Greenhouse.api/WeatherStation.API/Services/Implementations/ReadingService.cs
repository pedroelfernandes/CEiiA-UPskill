using MongoDB.Driver;
using WeatherStation.api.DTOs;
using WeatherStation.api.Models;
using WeatherStation.api.Repositories.Interfaces;
using WeatherStation.api.Services.Interfaces;

namespace WeatherStation.api.Services
{
    public class ReadingService:IReadingService
    {
        private readonly IReadingRepository _readingRepository;

        public ReadingService(IReadingRepository readingRepository)
        {
            _readingRepository = readingRepository;
        }

        public async Task<IReadOnlyList<ReadingDTO>> GetAllReadingsBySensorIdAsync(string id, string sort, int size, string order)
        {
            IReadOnlyList<Reading> readings = await _readingRepository.GetAllBySensorIdAsync(id, sort, size, order);

            return readings.Select(reading => ReadingDTO.ToDto(reading)).ToList();
        }


        public async Task<IReadOnlyList<SensorDTO>> GetSensorDetailsByIdListAsync(List<string> ids, string sort, string order)
        {
            //calling the entity before lets it be manipulated trough subsquent calls
            List<SensorDTO> result;

            IReadOnlyList<Reading> readings = await _readingRepository.GetSensorDetailsByIdListAsync(ids, sort, order);
            //List would never be null so check against item count
            if (readings.Count is not 0)
            {
                result = readings.Select(reading => SensorDTO.ToDto(reading)).ToList();
            }
            else
            {
                result = new();
            }

            return result;
        }

        public async Task<ReadingDTO> GetReadingByIdAsync(string id)
        {
            //ternary operetors rule! 
            Reading reading = await _readingRepository.GetReadingById(id) ?? throw new Exception("Reading not found");

            return ReadingDTO.ToDto(reading);
        }


        public async Task<DeleteResult> DeleteReadingByIdAsync(string id)
        {
            return await _readingRepository.DeleteAsync(id);
        }

    }
}
