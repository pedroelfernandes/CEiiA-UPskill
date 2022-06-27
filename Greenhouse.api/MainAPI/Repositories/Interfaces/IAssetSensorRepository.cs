using MainAPI.Models;

namespace MainAPI.Repositories.Interfaces
{
    public interface IAssetSensorRepository
    {
        public Task<List<AssetSensor>> GetAssetSensors(int assetId);

        public Task<bool> AddAssetSensor (int assetId, int sensorId);

        public Task<bool> RemoveAssetSensor (int assetId, int sensorId);
    }
}
