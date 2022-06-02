using MainAPI.Models;

namespace MainAPI.Repositories.Interfaces
{
    public interface ISensorTypeRepository
    {
        public Task<bool> Create(SensorType sensorType);

        public Task<SensorType> Get(int id);

        public Task<SensorType> Edit(SensorType sensorType);

        public Task<bool> Delete(int id);
    }
}
