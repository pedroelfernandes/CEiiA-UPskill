using MainAPI.HttpClientHelper;
using MainAPI.Models;

namespace MainAPI.Repositories.Interfaces
{
    public interface IAssetRepository
    {
        //Task<bool> CreateAsset(Asset asset);
        //Task<bool> DeleteAsset(int Id);
        Task<IEnumerable<Asset>> GetAssets(Enumerables.SortItem sort, Enumerables.OrderItem order);
        //Task<Asset> GetAssetById(int Id);
        //Task<bool> EditAsset(int Id);

    }
}
