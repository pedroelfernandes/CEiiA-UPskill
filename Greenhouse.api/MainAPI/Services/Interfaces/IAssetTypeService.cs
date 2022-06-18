using MainAPI.DTO;
using MainAPI.Models;

namespace MainAPI.Services.Interfaces
{
    public interface IAssetTypeService
    {
        Task<List<AssetTypeDTO>> GetAssetTypes();


        Task<AssetTypeDTO> GetAssetTypeById(int id);


        Task<AssetTypeDTO> CreateAssetType(AssetType assetType);


        Task<AssetTypeDTO> EditAssetType(AssetType assetType);


        Task<bool> ChangeStateAssetType(int id);
    }
}
