using MainAPI.Models;

namespace MainAPI.Repositories.Interfaces
{
    public interface IAssetRepository
    {
        Task<List<Asset>> GetAssets();


        Task<List<Asset>> GetActiveAssets();


        Task<Asset> GetAssetById(int Id);


        Task<Asset> EditAsset(Asset asset);


        Task<Asset> CreateAsset(Asset asset);


        Task<bool> ChangeState(int id);
    }
}
