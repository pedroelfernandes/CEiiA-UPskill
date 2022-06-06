using MainAPI.DTO;
using MainAPI.HttpClientHelper;
using MainAPI.Models;

namespace MainAPI.Services.Interfaces
{
    public interface IAssetTypeService
    {
        Task<IEnumerable<AssetTypeDTO>> GetAssetTypes(Enumerables.SortItem sort, Enumerables.OrderItem order);
        Task<AssetTypeDTO> GetAssetTypeById(int Id);
        Task<AssetTypeDTO> CreateAssetType(AssetTypeId assetType);
        Task<AssetTypeDTO> EditAssetType(int id, string name, string description, bool active);
        Task<bool> ChangeStateAssetType(int Id);
    }
}
