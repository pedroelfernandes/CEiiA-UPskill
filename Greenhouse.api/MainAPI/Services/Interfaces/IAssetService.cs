using MainAPI.DTO;
using MainAPI.HttpClientHelper;
using MainAPI.Models;

namespace MainAPI.Services.Interfaces
{
    public interface IAssetService
    {
        Task<List<AssetDTO>> GetAssets();
        Task<AssetDTO> GetAssetById(int Id);
        Task<AssetDTO> CreateAsset(Asset asset);
        //Task<AssetDTO> EditAsset(int id, string name, string company, string location, DateTime creationDate, AssetTypeId assetTypeId, bool active);
        Task<AssetDTO> EditAsset(Asset asset);
        Task<bool> ChangeState(int Id);

    }
}
