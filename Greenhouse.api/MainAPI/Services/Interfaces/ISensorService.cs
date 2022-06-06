using MainAPI.DTO;
using MainAPI.Models;

namespace MainAPI.Services.Interfaces
{
    public interface ISensorService
    {
        //Task<SensorDTO> Create(Sensor sensor);

        Task<SensorDTO> Get(int id);

        Task<SensorDTO> Edit(int id, string name, string description,
            string unit, int urlId, string company, DateTime activeSince, bool active, int sensorTypeId);

        Task<bool> ChangeState(int id);
    }
}
