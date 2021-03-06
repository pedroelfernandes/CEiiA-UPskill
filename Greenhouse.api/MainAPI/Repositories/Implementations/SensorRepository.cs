using MainAPI.Data;
using MainAPI.Models;
using MainAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MainAPI.Repositories.Implementations
{
    public class SensorRepository : ISensorRepository
    {
        private readonly ApplicationDbContext _db;

        private readonly ISensorTypeRepository _sensorTypeRepository;


        public SensorRepository(ApplicationDbContext db, ISensorTypeRepository sensorTypeRepository)
        {
            _db = db;
            _sensorTypeRepository = sensorTypeRepository;
        }


        public async Task<Sensor> Create(Sensor sensor)
        {
            if (sensor == null)
                throw new Exception("Sensor not defined.");

            await _db.Sensors.AddAsync(sensor);
            await _db.SaveChangesAsync();
            return sensor;  
        }


        public async Task<Sensor> GetSensor(int id)
        {
            Sensor sensor = await _db.Sensors.Include(s => s.SensorType).FirstAsync(s => s.Id == id);

            if (sensor == null)
                throw new Exception("Sensor not found.");

            return sensor;
        }


        public async Task<List<Sensor>> Get() =>
            await _db.Sensors.Include(s => s.SensorType).ToListAsync();


        public async Task<Sensor> Edit(Sensor sensor)
        {
            if (sensor == null)
                throw new Exception("Sensor not found.");

            _db.Sensors.Attach(sensor);
            _db.Entry(sensor).Property(s => s.Name).IsModified = true;
            _db.Entry(sensor).Property(s => s.Description).IsModified = true;
            _db.Entry(sensor).Property(s => s.Unit).IsModified = true;
            _db.Entry(sensor).Property(s => s.Company).IsModified = true;
            _db.Entry(sensor).Property(s => s.SensorTypeId).IsModified = true;

            await _db.SaveChangesAsync();

            return sensor;
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


        public async Task<bool> CheckForGenericSensors()
        {
            Sensor sensor = await _db.Sensors.FirstAsync(s => s.SensorTypeId == 1);

            if (sensor == null)
                return false;

            return true;
        }


        public bool FindInDb(Sensor sensor) =>
            _db.Sensors.Any(s => s.IdInAPI == sensor.IdInAPI && s.URLId == sensor.URLId);
    }
}
