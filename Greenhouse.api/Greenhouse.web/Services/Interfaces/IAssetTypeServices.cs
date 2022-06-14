using Greenhouse.web.Models;

namespace Greenhouse.web.Services.Interfaces
{
    public interface IAssetTypeServices
    {

        Task<IEnumerable<AssetType>> GetAssetTypes();
        Task<AssetType> CreateAssetType(AssetType assetType);

        //Task<AssetType> GetAssetTypeById(int Id);
        //Task<AssetType> EditAssetType(int id, string name, string description, bool active);
        //Task<bool> ChangeStateAssetType(int Id);
    }
}
