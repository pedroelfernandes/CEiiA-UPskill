using MainAPI.HttpClientHelper;
using MainAPI.Models;

namespace MainAPI.Repositories.Interfaces
{
    public interface IAssetTypeRepository
    {
        Task<IEnumerable<AssetType>> GetAssetTypes();
        Task<AssetType> GetAssetTypeById(int id);
        Task<AssetType> CreateAssetType(AssetType assetType);
        Task<AssetType> EditAssetType(int id, string name, string description, bool active);
        Task<bool> ChangeStateAssetType(int id);
    }
}
