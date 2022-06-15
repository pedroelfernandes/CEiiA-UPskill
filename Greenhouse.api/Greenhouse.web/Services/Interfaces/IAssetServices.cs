using Greenhouse.web.Models;

namespace Greenhouse.web.Services.Interfaces
{
    public interface IAssetServices
    {
        Task<IEnumerable<Asset>> GetAssets();
        //Task<Asset> GetAssetById(int Id);
        //Task<AssetType> CreateAsset(Asset asset);
        //Task<Asset> EditAsset(int id, string name, string description, bool active);
        //Task<bool> ChangeStateAssetType(int Id);

    }
}
