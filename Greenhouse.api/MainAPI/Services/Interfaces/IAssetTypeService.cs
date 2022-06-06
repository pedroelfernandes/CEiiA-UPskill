using MainAPI.DTO;
using MainAPI.HttpClientHelper;
using MainAPI.Models;

namespace MainAPI.Services.Interfaces
{
    public interface IAssetTypeService
    {
        Task<IEnumerable<AssetTypeDTO>> GetAssetTypes();
        Task<AssetTypeDTO> GetAssetTypeById(int Id);
        Task<AssetTypeDTO> CreateAssetType(AssetType assetType);
        Task<AssetTypeDTO> EditAssetType(int id, string name, string description, bool active);
        Task<bool> ChangeStateAssetType(int Id);
    }
}
