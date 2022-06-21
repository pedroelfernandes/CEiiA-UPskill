using MainAPI.Models;

namespace MainAPI.Repositories.Interfaces
{
    public interface ISensorRepository
    {
        public Task<Sensor> Create(Sensor sensor);


        public Task<Sensor> GetSensor(int id);


        public Task<List<Sensor>> Get();


        public Task<Sensor> Edit(Sensor sensor);


        public Task<bool> ChangeState(int id);


        public Task<bool> CheckForGenericSensors();


        public bool FindInDb(Sensor sensor);
    }
}
