using Greenhouse.web.Models;

namespace Greenhouse.web.Services.Interfaces
{
    public interface IReadingServices
    {
        Task<List<Reading>> GetSensorReadings(int sensorId, int size = 20);

        Task<List<Reading>> GetSensorReadingsBetweenDates(int sensorId, DateTime startDate, DateTime endDate);
    }
}
