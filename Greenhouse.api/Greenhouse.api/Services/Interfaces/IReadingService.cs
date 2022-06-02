using Greenhouse.api.DTOs;
using Greenhouse.api.Enumerables;

namespace Greenhouse.api.Services.Interfaces
{
    public interface IReadingService
    {
        Task<IReadOnlyList<ReadingDTO>> GetBySensorId(string sensorId, int size, SortEnum sort, OrderEnum order);
        Task<IReadOnlyList<ReadingDTO>> GetBetweenDatesBySensorId(string sensorId, DateTime startDate, DateTime endDate, SortEnum sort, OrderEnum order);
    }
}
