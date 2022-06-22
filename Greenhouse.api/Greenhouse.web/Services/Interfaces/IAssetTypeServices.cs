using Greenhouse.web.Models;

namespace Greenhouse.web.Services.Interfaces
{
    public interface IAssetTypeServices
    {
        Task<List<AssetType>> GetAssetTypes();
        Task<AssetType> CreateAssetType(AssetType assetType);
        Task<AssetType> GetAssetTypeById(int id);
        Task<AssetType> EditAssetType(AssetType assetType);
        Task<bool> ChangeStateAssetType(int id);
    }
}
