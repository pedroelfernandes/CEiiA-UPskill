using MainAPI.Models;

namespace MainAPI.Repositories.Interfaces
{
    public interface ISensorRepository
    {
        //public Task<bool> Create(Sensor sensor);

        public Task<Sensor> Get(int id);

        public Task<Sensor> Edit(int id, string name, string description,
            string unit, int urlId, string company, DateTime activeSince, bool active, int sensorTypeId);

        public Task<bool> ChangeState(int id);
    }
}
