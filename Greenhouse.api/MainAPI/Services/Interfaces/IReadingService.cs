using MainAPI.Models;

namespace MainAPI.Services.Interfaces
{
    public interface IReadingService
    {
        Task<IReadOnlyList<Reading>> GetBySensorId(string urlId, string sensorId, int size);


        Task<IReadOnlyList<Reading>> GetBetweenDatesBySensorId(string urlId, string sensorId, DateTime startDate, DateTime endDate);
    }
}
