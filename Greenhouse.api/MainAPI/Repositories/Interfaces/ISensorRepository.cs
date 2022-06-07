using MainAPI.Models;

namespace MainAPI.Repositories.Interfaces
{
    public interface ISensorRepository
    {
        public Task<Sensor> Create(Sensor sensor);


        public Task<Sensor> Get(int id);


        public Task<Sensor> Edit(int id, string name, string description,
            string unit, int urlId, string company, int sensorTypeId);


        public Task<bool> ChangeState(int id);
    }
}
