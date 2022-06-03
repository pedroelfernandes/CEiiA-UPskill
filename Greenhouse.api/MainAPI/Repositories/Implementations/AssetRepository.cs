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

        public async Task<Asset> GetAssetById(int id)
        {
            Asset asset;
            asset = await _db.Assets.FindAsync(id);
            return asset;
        }

        public async Task<IEnumerable<Asset>> GetAssets(Enumerables.SortItem sort, Enumerables.OrderItem order)
        {
            var assets = new List<Asset>();
            assets = await _db.Assets.ToListAsync();
            return assets;

        }

        public async Task<Asset> CreateAsset(Asset asset)
        {
            await _db.Assets.AddAsync(asset);
            await _db.SaveChangesAsync();
            return asset;
        }

        public async Task<Asset> EditAsset(int id, string name, string company, string location, DateTime creationDate, AssetType assetType, bool active)
        {
            _db.Assets.Update(await GetAssetById(id)).Property(a => a.Name).CurrentValue = name;
            _db.Assets.Update(await GetAssetById(id)).Property(a => a.Company).CurrentValue = company;
            _db.Assets.Update(await GetAssetById(id)).Property(a => a.Location).CurrentValue = location;
            _db.Assets.Update(await GetAssetById(id)).Property(a => a.CreationDate).CurrentValue = creationDate;
            _db.Assets.Update(await GetAssetById(id)).Property(a => a.AssetType).CurrentValue = assetType;
            _db.Assets.Update(await GetAssetById(id)).Property(a => a.Active).CurrentValue = active;

            await _db.SaveChangesAsync();
            return await GetAssetById(id);
        }


        public async Task<bool> ChangeState(int id)
        {
            Asset? asset;
            asset = await _db.Assets.FindAsync(id);

            if(asset == null)
                return false;

            asset.Active ^= true;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
