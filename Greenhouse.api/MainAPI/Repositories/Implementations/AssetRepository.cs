using MainAPI.Data;
using MainAPI.HttpClientHelper;
using MainAPI.Models;
using MainAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MainAPI.Repositories.Implementations
{
    public class AssetRepository : IAssetRepository
    {
        private readonly ApplicationDbContext _db;


        public AssetRepository(ApplicationDbContext db)
        {
            _db = db;
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


        public async Task<Asset> CreateAsset(Asset asset)
        {
            if (asset == null)
                throw new Exception("Asset not defined.");

            await _db.Assets.AddAsync(asset);
            await _db.SaveChangesAsync();
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
