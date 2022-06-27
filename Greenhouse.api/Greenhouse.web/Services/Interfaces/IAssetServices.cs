using Greenhouse.web.Models;

namespace Greenhouse.web.Services.Interfaces
{
    public interface IAssetServices
    {
        Task<IEnumerable<Asset>> GetAssets();
        Task<Asset> CreateAsset(Asset asset);
        Task<Asset> GetAssetById(int id);
        Task<Asset> EditAsset(Asset asset);
        Task<bool> ChangeStateAsset(int id);
        Task<bool> RemoveAssetSensor(int assetId, int sensorId);
        Task<bool> AddAssetSensor(int assetId, int sensorId);
    }
}
