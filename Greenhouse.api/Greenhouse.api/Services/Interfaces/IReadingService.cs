using Greenhouse.api.DTOs;

namespace Greenhouse.api.Services.Interfaces
{
    public interface IReadingService
    {
        Task<IReadOnlyList<ReadingDTO>> GetBySensorId(string sensorId, int size, string sort, string order);
        Task<IReadOnlyList<ReadingDTO>> GetBetweenDatesBySensorId(string sensorId, DateTime startDate, DateTime endDate, string sort, string order);
    }
}
