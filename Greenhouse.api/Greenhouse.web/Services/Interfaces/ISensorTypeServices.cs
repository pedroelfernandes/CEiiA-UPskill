using Greenhouse.web.Models;

namespace Greenhouse.web.Services.Interfaces
{
    public interface ISensorTypeServices
    {
        //Task<IEnumerable<SensorType>> Get(); - NOT IMPLEMENTED IN THE MAIN API
        Task<List<SensorType>> Get();
        
        Task<SensorType> GetSensorTypeById(int id);
        Task<SensorType> Create(SensorType sensorType);
        Task<SensorType> Edit(SensorType sensorType);
        //Task<bool> ChangeStateSensorType(int id);
    }
}
