using MainAPI.Data;
using MainAPI.HttpClientHelper;
using MainAPI.Models;
using MainAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MainAPI.Repositories.Implementations
{
    public class AssetTypeRepository : IAssetTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public AssetTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<AssetType>> GetAssetTypes()
        {
            var assetTypes =  await _db.AssetTypes.ToListAsync();
            return assetTypes;
        }


        public async Task<AssetType> GetAssetTypeById(int id)
        {
            AssetType assetType = await _db.AssetTypes.FindAsync(id);

            if (assetType == null)
                throw new Exception("AssetTypep not found.");

            return assetType;
        }

        public async Task<AssetType> CreateAssetType(AssetType assetType)
        {
            if (assetType == null)
                throw new Exception("AssetType not defined.");

            await _db.AssetTypes.AddAsync(assetType);
            await _db.SaveChangesAsync();
            return assetType;
        }

        public async Task<AssetType> EditAssetType(int id, string name, string description, bool active)
        {
            _db.AssetTypes.Update(await GetAssetTypeById(id)).Property(a => a.Name).CurrentValue = name;
            _db.AssetTypes.Update(await GetAssetTypeById(id)).Property(a => a.Description).CurrentValue = description;
            _db.AssetTypes.Update(await GetAssetTypeById(id)).Property(a => a.IsActive).CurrentValue = active;

            await _db.SaveChangesAsync();
            return await GetAssetTypeById(id);
        }


        public async Task<bool> ChangeStateAssetType(int id)
        {
            AssetType? assetType = await _db.AssetTypes.FindAsync(id);

            if (assetType == null)
                return false;

            assetType.IsActive ^= true;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
