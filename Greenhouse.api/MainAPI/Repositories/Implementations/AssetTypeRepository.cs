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

        public async Task<IEnumerable<AssetTypeId>> GetAssetTypes(Enumerables.SortItem sort, Enumerables.OrderItem order)
        {
            var assetTypes = new List<AssetTypeId>();
            assetTypes = await _db.AssetTypes.ToListAsync();
            return assetTypes;
        }


        public async Task<AssetTypeId> GetAssetTypeById(int id)
        {
            AssetTypeId assetType;
            assetType = await _db.AssetTypes.FindAsync(id);
            return assetType;
        }

        public async Task<AssetTypeId> CreateAssetType(AssetTypeId assetType)
        {
            await _db.AssetTypes.AddAsync(assetType);
            await _db.SaveChangesAsync();
            return assetType;
        }

        public async Task<AssetTypeId> EditAssetType(int id, string name, string description, bool active)
        {
            _db.AssetTypes.Update(await GetAssetTypeById(id)).Property(a => a.Name).CurrentValue = name;
            _db.AssetTypes.Update(await GetAssetTypeById(id)).Property(a => a.Description).CurrentValue = description;
            _db.AssetTypes.Update(await GetAssetTypeById(id)).Property(a => a.Active).CurrentValue = active;

            await _db.SaveChangesAsync();
            return await GetAssetTypeById(id);
        }


        public async Task<bool> ChangeStateAssetType(int id)
        {
            AssetTypeId? assetType;
            assetType = await _db.AssetTypes.FindAsync(id);

            if (assetType == null)
                return false;

            assetType.Active ^= true;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
