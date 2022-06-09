using MainAPI.Data;
using MainAPI.Models;
using MainAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MainAPI.Repositories.Implementations
{
    public class SensorRepository : ISensorRepository
    {
        private readonly ApplicationDbContext _db;


        public SensorRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<Sensor> Create(Sensor sensor)
        {
            if (sensor == null)
                throw new Exception("Sensor not defined.");

            await _db.Sensors.AddAsync(sensor);
            await _db.SaveChangesAsync();

            return sensor;
        }


        public async Task<Sensor> Get(int id)
        {
            Sensor sensor = await _db.Sensors.FindAsync(id);

            if (sensor == null)
                throw new Exception("Sensor not found.");

            return sensor;
        }


        public async Task<Sensor> Edit(int id, string name, string description,
            string unit, int urlId, string company, int sensorTypeId)
        {
            _db.Sensors.Update(await Get(id)).Property(r => r.Name).CurrentValue = name;
            _db.Sensors.Update(await Get(id)).Property(r => r.Description).CurrentValue = description;
            _db.Sensors.Update(await Get(id)).Property(r => r.Unit).CurrentValue = unit;
            _db.Sensors.Update(await Get(id)).Property(r => r.URLId).CurrentValue = urlId;
            _db.Sensors.Update(await Get(id)).Property(r => r.Company).CurrentValue = company;
            _db.Sensors.Update(await Get(id)).Property(r => r.SensorTypeId).CurrentValue = sensorTypeId;
            await _db.SaveChangesAsync();
            return await Get(id);
        }


        public async Task<bool> ChangeState(int id)
        {
            Sensor sensor = await _db.Sensors.FindAsync(id);

            if (sensor == null)
                return false;

            sensor.IsActive ^= true;
            await _db.SaveChangesAsync();

            return true;
        }


        public bool FindInDb(Sensor sensor) =>
            _db.Sensors.Any(s => s.IdInAPI == sensor.IdInAPI && s.URLId == sensor.URLId);
    }
}
