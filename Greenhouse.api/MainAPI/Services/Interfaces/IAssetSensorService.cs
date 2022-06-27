using MainAPI.Models;

namespace MainAPI.Services.Interfaces
{
    public interface IAssetSensorService
    {
        public Task<List<AssetSensor>> GetAssetSensors(int assetId);

        public Task<bool> AddAssetSensor (int assetId, int sensorId);

        public Task<bool> RemoveAssetSensor(int assetId, int sensorId);

    }
}
