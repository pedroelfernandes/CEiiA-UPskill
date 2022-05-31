using MongoDB.Driver;
using Greenhouse.api.Models;

namespace Greenhouse.api.Repositories.Interfaces
{
    public interface IReadingRepository
    {
        Task<IReadOnlyList<Reading>> GetBySensorId(string sensorId, int size, string sort, string order);
        Task<IReadOnlyList<Reading>> GetBetweenDatesBySensorId(string sensorId, DateTime startDate, DateTime endDate, string sort, string order);
    }
}
