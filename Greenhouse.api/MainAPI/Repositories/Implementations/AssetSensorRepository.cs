using MainAPI.Data;
using MainAPI.Models;
using MainAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MainAPI.Repositories.Implementations
{
    public class AssetSensorRepository : IAssetSensorRepository
    {
        private readonly ApplicationDbContext _db;


        public AssetSensorRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<List<AssetSensor>> GetAssetSensors(int assetId) =>
            await _db.AssetSensors.Where(a => a.AssetId == assetId).Include(a => a.Sensor).Include(a => a.Sensor.SensorType).ToListAsync();

        public async Task<bool> AddAssetSensor(int assetId, int sensorId)
        {
            AssetSensor assetSensor = new AssetSensor { AssetId = assetId, SensorId = sensorId };
            await _db.AssetSensors.AddAsync(assetSensor);

            await _db.SaveChangesAsync();

            if ((await _db.AssetSensors.FirstAsync(a => a.AssetId == assetId && a.SensorId == sensorId)) == null)
                return false;

            return true;
        }


        public async Task<bool> RemoveAssetSensor(int assetId, int sensorId)
        {
            AssetSensor assetSensor = new AssetSensor { AssetId = assetId, SensorId = sensorId };
            _db.AssetSensors.Remove(assetSensor);

            await _db.SaveChangesAsync();

            if ((await _db.AssetSensors.FirstAsync(a => a.AssetId == assetId && a.SensorId == sensorId)) == null)
                return false;

            return true;
        }
    }
}
