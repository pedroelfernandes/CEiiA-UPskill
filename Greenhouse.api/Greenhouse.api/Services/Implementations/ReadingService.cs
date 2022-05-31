using Greenhouse.api.DTOs;
using Greenhouse.api.Models;
using Greenhouse.api.Repositories.Interfaces;
using Greenhouse.api.Services.Interfaces;

namespace Greenhouse.api.Services.Implementations
{
    public class ReadingService : IReadingService
    {
        private readonly IReadingRepository _readingRepository;


        public ReadingService(IReadingRepository readingRepository)
        {
            _readingRepository = readingRepository;
        }


        public async Task<IReadOnlyList<ReadingDTO>> GetBySensorId(string sensorId, int size, string sort, string order)
        {
            IReadOnlyList<Reading> readings = await _readingRepository.GetBySensorId(sensorId, size, sort, order);

            return readings.Select(reading => ReadingDTO.ToDto(reading)).ToList();
        }


        public async Task<IReadOnlyList<ReadingDTO>> GetBetweenDatesBySensorId(string sensorId, DateTime startDate, DateTime endDate, string sort, string order)
        {
            IReadOnlyList<Reading> readings = await _readingRepository.GetBetweenDatesBySensorId(sensorId, startDate, endDate, sort, order);

            return readings.Select(reading => ReadingDTO.ToDto(reading)).ToList();
        }
    }
}
