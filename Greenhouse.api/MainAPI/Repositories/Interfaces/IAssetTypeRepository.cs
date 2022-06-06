using MainAPI.HttpClientHelper;
using MainAPI.Models;

namespace MainAPI.Repositories.Interfaces
{
    public interface IAssetTypeRepository
    {
        Task<IEnumerable<AssetTypeId>> GetAssetTypes(Enumerables.SortItem sort, Enumerables.OrderItem order);
        Task<AssetTypeId> GetAssetTypeById(int id);
        Task<AssetTypeId> CreateAssetType(AssetTypeId assetType);
        Task<AssetTypeId> EditAssetType(int id, string name, string description, bool active);
        Task<bool> ChangeStateAssetType(int id);
    }
}
