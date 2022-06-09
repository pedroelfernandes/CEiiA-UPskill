using MainAPI.Models;

namespace MainAPI.Services.Interfaces
{
    public interface IReadingService
    {
        Task<IReadOnlyList<Reading>> GetBySensorId(int urlId, string sensorId, int size);


        Task<IReadOnlyList<Reading>> GetBetweenDatesBySensorId(int urlId, string sensorId, DateTime startDate, DateTime endDate);
    }
}
