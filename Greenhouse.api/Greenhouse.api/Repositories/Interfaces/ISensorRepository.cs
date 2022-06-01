using Greenhouse.api.Models;

namespace Greenhouse.api.Repositories.Interfaces
{
    public interface ISensorRepository
    {
        //Task<IReadOnlyList<Sensor>> GetSensors(string sort, string order);
        Task<Sensor> GetSensorById(string id);
        Task<IReadOnlyList<Sensor>> GetAllSensors();
    }
}
