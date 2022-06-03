using MainAPI.DTO;
using MainAPI.HttpClientHelper;
using MainAPI.Models;

namespace MainAPI.Services.Interfaces
{
    public interface IAssetService
    {
        Task<IEnumerable<AssetDTO>> GetAssets(Enumerables.SortItem sort, Enumerables.OrderItem order);
        Task<AssetDTO> GetAssetById(int Id);
        Task<AssetDTO> CreateAsset(Asset asset);
        Task<AssetDTO> EditAsset(int id, string name, string company, string location, DateTime creationDate, AssetType assetType, bool active);
        Task<bool> ChangeState(int Id);

    }
}
