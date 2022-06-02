using MainAPI.Data;
using MainAPI.Models;
using MainAPI.Repositories.Interfaces;

namespace MainAPI.Repositories.Implementations
{
    public class SensorRepository : ISensorRepository
    {
        private readonly ApplicationDbContext _db;

        public SensorRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Sensor sensor)
        {
            if (sensor == null)
                return false;

            await _db.Sensors.AddAsync(sensor);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Sensor> Get(int id)
        {
            Sensor? sensor;

            // get the sensor
            sensor = await _db.Sensors.FindAsync(id);
            return sensor;
        }

        public async Task<Sensor> Edit(Sensor sensor)
        {
            _db.Sensors.Update(sensor);
            await _db.SaveChangesAsync();
            return sensor;
        }

        public async Task<bool> Delete(int id)
        {
            Sensor? sensor;

            sensor = await _db.Sensors.FindAsync();

            if (sensor == null)
                return false;

            _db.Sensors.Update(sensor).Property(u => u.Active).CurrentValue = false;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
