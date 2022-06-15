using MainAPI.DTO;
using MainAPI.Models;

namespace MainAPI.Services.Interfaces
{
    public interface ISensorTypeService
    {
        Task<SensorTypeDTO> Create(SensorType sensorType);


        Task<SensorTypeDTO> Get(int id);


        Task<SensorTypeDTO> Edit(SensorType sensorType);


        Task<bool> ChangeState(int id);
    }
}
