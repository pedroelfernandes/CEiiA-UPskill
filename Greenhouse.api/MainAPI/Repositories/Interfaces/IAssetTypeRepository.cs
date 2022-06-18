using MainAPI.Models;

namespace MainAPI.Repositories.Interfaces
{
    public interface IAssetTypeRepository
    {
        Task<List<AssetType>> GetAssetTypes();


        Task<AssetType> GetAssetTypeById(int id);


        Task<AssetType> CreateAssetType(AssetType assetType);


        Task<AssetType> EditAssetType(AssetType assetType);


        Task<bool> ChangeStateAssetType(int id);
    }
}
