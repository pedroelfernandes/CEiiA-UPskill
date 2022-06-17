using MainAPI.Models;

namespace MainAPI.Repositories.Interfaces
{
    public interface ISensorTypeRepository
    {
        public Task<SensorType> Create(SensorType sensorType);

        public Task<List<SensorType>> Get();
        public Task<SensorType> GetSensorTypeById(int id);

        public Task<SensorType> Edit(SensorType sensorType);

        public Task<bool> ChangeState(int id);
    }
}
