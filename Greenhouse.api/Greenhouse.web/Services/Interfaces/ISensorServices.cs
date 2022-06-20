using Greenhouse.web.Models;

namespace Greenhouse.web.Services.Interfaces
{
    public interface ISensorServices
    {
        Task<List<Sensor>> Get();
        Task<Sensor> GetSensorById(int id);
        Task<Sensor> Create(Sensor sensor);
        Task<Sensor> Edit(Sensor sensor);
        Task<bool> ChangeState(int Id);
    }
}
