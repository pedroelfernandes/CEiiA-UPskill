using MainAPI.Data;
using MainAPI.Models;
using MainAPI.Repositories.Interfaces;

namespace MainAPI.Repositories.Implementations
{
    public class SensorTypeRepository : ISensorTypeRepository
    {

        private readonly ApplicationDbContext _db;

        public SensorTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<SensorType> Create(SensorType sensorType)
        {
            if (sensorType == null)
                throw new Exception("SensorType not defined.");

            await _db.SensorTypes.AddAsync(sensorType);
            await _db.SaveChangesAsync();
            return sensorType;
        }

        public async Task<SensorType> Get(int id)
        {
            SensorType? sensorType = await _db.SensorTypes.FindAsync(id);

            if (sensorType == null)
                throw new Exception("SensorType not found.");

            return sensorType;
        }

        public async Task<SensorType> Edit(int id, string name, string description)
        {
            _db.SensorTypes.Update(await Get(id)).Property(r => r.Name).CurrentValue = name;
            _db.SensorTypes.Update(await Get(id)).Property(r => r.Description).CurrentValue = description;
            await _db.SaveChangesAsync();
            return await Get(id);
        }

        public async Task<bool> ChangeState(int id)
        {
            SensorType? sensorType = await _db.SensorTypes.FindAsync(id);

            if (sensorType == null)
                return false;

            sensorType.IsActive ^= true;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
