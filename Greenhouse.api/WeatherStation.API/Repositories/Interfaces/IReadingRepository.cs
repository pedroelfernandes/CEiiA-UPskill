using MongoDB.Driver;
using WeatherStation.api.Models;

namespace WeatherStation.api.Repositories.Interfaces;

public interface IReadingRepository
{
    Task<IReadOnlyList<Reading>> GetAllBySensorIdAsync(string id, string sort, int size, string order);
    Task<IReadOnlyList<Reading>> GetSensorDetailsByIdListAsync(List<string> ids, string sort, string order);
    Task<Reading> GetReadingById(string id);
    Task<Reading> CreateAsync(Reading reading);
    Task<Reading> UpdateAsync(Reading reading);
    Task<DeleteResult> DeleteAsync(string id);
}
