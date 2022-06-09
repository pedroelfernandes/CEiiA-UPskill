using Greenhouse.web.Models;

namespace Greenhouse.web.Services.Interfaces
{
    public interface IAssetServices
    {
        Task<IEnumerable<Asset>> GetAssets();
        //Task<AssetType> GetAssetTypeById(int Id);
        //Task<AssetType> CreateAssetType(AssetType assetType);
        //Task<AssetType> EditAssetType(int id, string name, string description, bool active);
        //Task<bool> ChangeStateAssetType(int Id);
    }
}

