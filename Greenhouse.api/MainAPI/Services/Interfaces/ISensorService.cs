using MainAPI.DTO;
using MainAPI.Models;

namespace MainAPI.Services.Interfaces
{
    public interface ISensorService
    {
        Task<SensorDTO> Create(Sensor sensor);

        Task<SensorDTO> Get(int id);

        Task<SensorDTO> Edit(Sensor sensor);

        Task<bool> Delete(int id);
    }
}
