using MainAPI.Models;

namespace MainAPI.Repositories.Interfaces
{
    public interface ISensorTypeRepository
    {
        public Task<SensorType> Create(SensorType sensorType);

        public Task<SensorType> Get(int id);

        public Task<SensorType> Edit(int id, string name, string description);

        public Task<bool> ChangeState(int id);
    }
}
