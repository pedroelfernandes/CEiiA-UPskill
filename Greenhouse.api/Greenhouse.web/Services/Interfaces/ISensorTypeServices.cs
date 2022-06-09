using Greenhouse.web.Models;

namespace Greenhouse.web.Services.Interfaces
{
    public interface ISensorTypeServices
    {
        Task<IEnumerable<SensorType>> GetSensorTypes();
        //Task<SensorType> GetSensorTypeById(int Id);
        //Task<SensorType> CreateSensorType(SensorType sensorType);
        //Task<SensorType> EditSensorType(int id, string name, string description, bool active);//CHECK THAT
        //Task<bool> ChangeStateSensorType(int Id);
    }
}
