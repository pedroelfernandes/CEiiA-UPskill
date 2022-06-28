using Greenhouse.web.Models;

namespace Greenhouse.web.Services.Interfaces
{
    public interface IAssetServices
    {
        Task<List<Asset>> GetAssets();
        Task<Asset> CreateAsset(Asset asset);
        Task<Asset> GetAssetById(int id);
        Task<Asset> EditAsset(Asset asset);
        Task<bool> ChangeStateAsset(int id);
    }
}
