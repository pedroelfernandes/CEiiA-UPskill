using Greenhouse.api.DTOs;

namespace Greenhouse.api.Services.Interfaces
{
    public interface ISensorService
    {
        Task<SensorDTO> GetSensorById(string id);
        Task<IReadOnlyList<SensorDTO>> GetAllSensors();
    }
}
