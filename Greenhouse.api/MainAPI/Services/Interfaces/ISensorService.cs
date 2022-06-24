using MainAPI.DTO;
using MainAPI.Models;

namespace MainAPI.Services.Interfaces
{
    public interface ISensorService
    {
        Task<SensorDTO> Create(Sensor sensor);


        Task<List<SensorDTO>> Get();


        Task<SensorDTO> GetSensor(int id);


        Task<SensorDTO> Edit(SensorDTO sensor);


        Task<bool> ChangeState(int id);


        Task<bool> CheckForGenericSensors();


        Task<bool> CheckForNewSensors();
    }
}
