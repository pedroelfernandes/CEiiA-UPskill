using MongoDB.Driver;
using WeatherStation.api.Enumerables;
using WeatherStation.api.Models;    

namespace WeatherStation.api.Repositories.Interface
{
    public interface IReadingRepository
    {
        Task<IReadOnlyList<Reading>> GetBySensorId(string sensorId, int size, SortEnum sort, OrderEnum order);
        Task<IReadOnlyList<Reading>> GetBetweenDatesBySensorId(string sensorId, DateTime startDate, DateTime endDate, SortEnum sort, OrderEnum order);
    }
}
