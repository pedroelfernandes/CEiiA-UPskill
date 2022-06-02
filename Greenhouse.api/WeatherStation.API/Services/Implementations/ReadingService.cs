using WeatherStation.api.DTOs;
using WeatherStation.api.Enumerables;
using WeatherStation.api.Models;
using WeatherStation.api.Repositories.Interface;
using WeatherStation.api.Services.Interfaces;

namespace WeatherStation.api.Services.Implementations
{
    public class ReadingService : IReadingService
    {
        private readonly IReadingRepository _readingRepository;


        public ReadingService(IReadingRepository readingRepository)
        {
            _readingRepository = readingRepository;
        }

        public async Task<IReadOnlyList<ReadingDTO>> GetBySensorId(string sensorId, int size, SortEnum sort, OrderEnum order)
        {
            IReadOnlyList<Reading> readings = await _readingRepository.GetBySensorId(sensorId, size, sort, order);

            return readings.Select(reading => ReadingDTO.ToDto(reading)).ToList();
        }


        public async Task<IReadOnlyList<ReadingDTO>> GetBetweenDatesBySensorId(string sensorIid, DateTime startDate, DateTime endDate, SortEnum sort, OrderEnum order)
        {
            IReadOnlyList<Reading> readings= await _readingRepository.GetBetweenDatesBySensorId(sensorIid, startDate, endDate, sort, order);

            return readings.Select(reading => ReadingDTO.ToDto(reading)).ToList();
        }

        
    }
}
