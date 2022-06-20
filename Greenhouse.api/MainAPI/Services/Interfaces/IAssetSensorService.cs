using MainAPI.Models;

namespace MainAPI.Services.Interfaces
{
    public interface IAssetSensorService
    {
        public Task<List<AssetSensor>> GetAssetSensors(int assetId);
    }
}
