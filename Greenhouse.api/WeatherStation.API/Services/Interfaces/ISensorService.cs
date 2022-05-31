using WeatherStation.api.DTOs;

namespace WeatherStation.api.Services.Interfaces
{
    public interface ISensorService
    {
        Task<SensorDTO> GetSensorById(string id);
    }
}
