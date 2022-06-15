using MainAPI.Models;

namespace MainAPI.Repositories.Interfaces
{
    public interface ISensorRepository
    {
        public Task<Sensor> Create(Sensor sensor);


        public Task<Sensor> Get(int id);


        public Task<Sensor> Edit(Sensor sensor);


        public Task<bool> ChangeState(int id);


        public bool FindInDb(Sensor sensor);
    }
}
