using MainAPI.Models;

namespace MainAPI.Repositories.Interfaces
{
    public interface IAssetSensorRepository
    {
        public Task<List<AssetSensor>> GetAssetSensors(int assetId);
    }
}
