using Greenhouse.web.Models;

namespace Greenhouse.web.Services.Interfaces
{
    public interface ISensorTypeServices
    {
        //Task<IEnumerable<SensorType>> Get(); - NOT IMPLEMENTED IN THE MAIN API
        Task<SensorType> Get(int Id);
        //Task<SensorType> GetSensorTypeById(int id);
        //Task<SensorType> CreateSensorType(SensorType sensorType);
        //Task<SensorType> EditSensorType(int id, string name, string description, bool active);//CHECK THAT
        //Task<bool> ChangeStateSensorType(int id);
    }
}
