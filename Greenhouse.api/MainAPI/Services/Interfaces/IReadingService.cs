using MainAPI.Models;

namespace MainAPI.Services.Interfaces
{
    public interface IReadingService
    {
        Task<List<Reading>> GetBySensorId(int urlId, string sensorId, int size);


        Task<List<Reading>> GetBetweenDatesBySensorId(int urlId, string sensorId, DateTime startDate, DateTime endDate);
    }
}
