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

        public async Task<bool> Create(SensorType sensorType)
        {
            if (sensorType == null)
                return false;

            await _db.SensorTypes.AddAsync(sensorType);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<SensorType> Get(int id)
        {
            SensorType? sensorType;

            // get the sensor
            sensorType = await _db.SensorTypes.FindAsync(id);
            return sensorType;
        }

        public async Task<SensorType> Edit(SensorType sensorType)
        {
            _db.SensorTypes.Update(sensorType);
            await _db.SaveChangesAsync();
            return sensorType;
        }

        public async Task<bool> Delete(int id)
        {
            SensorType? sensorType;

            sensorType = await _db.SensorTypes.FindAsync();

            if (sensorType == null)
                return false;

            _db.SensorTypes.Update(sensorType).Property(u => u.Active).CurrentValue = false;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
