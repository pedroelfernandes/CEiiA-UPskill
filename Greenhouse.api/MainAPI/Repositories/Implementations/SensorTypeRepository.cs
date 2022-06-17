using MainAPI.Data;
using MainAPI.Models;
using MainAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<SensorType>> Get()
        {
            var sensorTypes = await _db.SensorTypes.ToListAsync();
            return sensorTypes;
        }


        public async Task<SensorType> GetSensorTypeById(int id)
        {
            SensorType sensorType = await _db.SensorTypes.FindAsync(id);

            if(sensorType == null)
            {
                throw new Exception("SensorType note found.");
            }

            return sensorType;
        }


        public async Task<SensorType> Edit(SensorType sensorType)
        {
            if(sensorType == null)
                throw new Exception("SensorType not defined.");
            _db.SensorTypes.Update(sensorType);
            await _db.SaveChangesAsync();
            return sensorType;
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
