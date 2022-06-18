using Greenhouse.web.Models;

namespace Greenhouse.web.Services.Interfaces
{
    public interface ISensorTypeServices
    {
        //Task<IEnumerable<SensorType>> Get(); - NOT IMPLEMENTED IN THE MAIN API
        Task<List<SensorType>> Get();
        Task<SensorType> GetById(int id);
        //Task<SensorType> GetSensorTypeById(int id);
        Task<SensorType> Create(SensorType sensorType);
        //Task<SensorType> EditSensorType(int id, string name, string description, bool active);//CHECK THAT
        //Task<bool> ChangeStateSensorType(int id);
    }
}
