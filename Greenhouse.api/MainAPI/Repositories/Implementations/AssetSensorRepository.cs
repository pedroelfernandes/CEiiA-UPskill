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
    }
}
