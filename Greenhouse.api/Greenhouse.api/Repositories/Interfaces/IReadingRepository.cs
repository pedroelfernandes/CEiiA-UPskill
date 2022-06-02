using MongoDB.Driver;
using Greenhouse.api.Models;
using Greenhouse.api.Enumerables;

namespace Greenhouse.api.Repositories.Interfaces
{
    public interface IReadingRepository
    {
        Task<IReadOnlyList<Reading>> GetBySensorId(string sensorId, int size, SortEnum sort, OrderEnum order);
        Task<IReadOnlyList<Reading>> GetBetweenDatesBySensorId(string sensorId, DateTime startDate, DateTime endDate, SortEnum sort, OrderEnum order);
    }
}
