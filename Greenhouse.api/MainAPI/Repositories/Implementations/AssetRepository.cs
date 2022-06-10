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

        public async Task<IEnumerable<Asset>> GetAssets()
        {
            return await _db.Assets.Include(a => a.AssetType).ToListAsync();

            //List<int> index = _db.Assets.Select(x => x.Id).ToList();
            //List<Asset> assets;

            //foreach (int id in index)
            //{
            //    assets.Add(await _db.Assets.FindAsync(id));
            //}
            //if (assets == null) 
            //    throw new Exception("Asset not found");
            //return assets;
        }


        public async Task<Asset> GetAssetById(int id)
        {
            Asset asset = await _db.Assets.FindAsync(id);

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

        //public async Task<Asset> EditAsset(int id, string name, string company, string location, DateTime creationDate, AssetTypeId assetTypeId, bool active)
        //{
        //    _db.Assets.Update(await GetAssetById(id)).Property(a => a.Name).CurrentValue = name;
        //    _db.Assets.Update(await GetAssetById(id)).Property(a => a.Company).CurrentValue = company;
        //    _db.Assets.Update(await GetAssetById(id)).Property(a => a.Location).CurrentValue = location;
        //    _db.Assets.Update(await GetAssetById(id)).Property(a => a.CreationDate).CurrentValue = creationDate;
        //    _db.Assets.Update(await GetAssetById(id)).Property(a => a.AssetTypeId).CurrentValue = assetTypeId;
        //    _db.Assets.Update(await GetAssetById(id)).Property(a => a.Active).CurrentValue = active;

        //    await _db.SaveChangesAsync();
        //    return await GetAssetById(id);
        //}

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
