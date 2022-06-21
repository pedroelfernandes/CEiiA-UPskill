using MainAPI.DTO;
using MainAPI.Models;

namespace MainAPI.Services.Interfaces
{
    public interface IAssetService
    {
        Task<List<AssetDTO>> GetAssets();


        Task<List<AssetDTO>> GetActiveAssets();


        Task<AssetDTO> GetAssetById(int Id);


        Task<AssetDTO> CreateAsset(Asset asset);


        Task<AssetDTO> EditAsset(Asset asset);


        Task<bool> ChangeState(int Id);
    }
}
