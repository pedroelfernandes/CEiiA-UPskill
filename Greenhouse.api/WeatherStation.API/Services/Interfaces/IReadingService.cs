using MongoDB.Driver;
using System.Threading.Tasks;
using WeatherStation.api.DTOs;

namespace WeatherStation.api.Services.Interfaces;

public interface IReadingService
{
    Task<IReadOnlyList<ReadingDTO>> GetAllReadingsBySensorIdAsync(string id, string sort, int size, string order);
    Task<IReadOnlyList<SensorDTO>> GetSensorDetailsByIdListAsync(List<string> ids, string sort, string order);
    Task<ReadingDTO> GetReadingByIdAsync(string id);
    Task<DeleteResult> DeleteReadingByIdAsync(string id);
}
