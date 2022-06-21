using MainAPI.Data;
using MainAPI.Models;
using MainAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MainAPI.Repositories.Implementations
{
    public class AssetRepository : IAssetRepository
    {
        private readonly ApplicationDbContext _db;

        private readonly IAssetTypeRepository _assetTypeRepository;


        public AssetRepository(ApplicationDbContext db, IAssetTypeRepository assetTypeRepository)
        {
            _db = db;
            _assetTypeRepository = assetTypeRepository;
        }


        public async Task<List<Asset>> GetAssets() =>
            await _db.Assets.Include(a => a.AssetType).ToListAsync();


        public async Task<Asset> GetAssetById(int id)
        {
            Asset asset = await _db.Assets.Include(a => a.AssetType).FirstAsync(a => a.Id == id);

            if (asset == null)
                throw new Exception("Asset not found.");

            return asset;
        }


        public async Task<List<Asset>> GetActiveAssets() =>
            await _db.Assets.Where(a => a.IsActive).ToListAsync();


        public async Task<Asset> CreateAsset(Asset asset)
        {
            if (asset == null)
                throw new Exception("Asset not defined.");

            await _db.Assets.AddAsync(asset);
            await _db.SaveChangesAsync();

            asset.AssetType = await _assetTypeRepository.GetAssetTypeById(asset.AssetTypeId);

            return asset;
        }


        public async Task<Asset> EditAsset(Asset asset)
        {
            if (asset == null)
                throw new Exception("Asset not defined.");

            _db.Assets.Update(asset);
            await _db.SaveChangesAsync();
            return asset;
        }


        public async Task<bool> ChangeState(int id)
        {
            Asset? asset = await _db.Assets.FindAsync(id);

            if(asset == null)
                return false;

            asset.IsActive ^= true;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
