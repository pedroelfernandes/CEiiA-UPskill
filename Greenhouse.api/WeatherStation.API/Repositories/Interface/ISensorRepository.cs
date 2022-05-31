using WeatherStation.api.Models;

namespace WeatherStation.api.Repositories.Interface
{
    public interface ISensorRepository
    {
        //Task<IReadOnlyList<Sensor>> GetSensors(string sort, string order);
        Task<Sensor> GetSensorById(string id);
    }
}
