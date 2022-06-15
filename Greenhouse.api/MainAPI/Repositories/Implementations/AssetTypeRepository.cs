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


        public async Task<List<AssetType>> GetAssetTypes() =>
            await _db.AssetTypes.ToListAsync();


        public async Task<AssetType> GetAssetTypeById(int id)
        {
            AssetType assetType = await _db.AssetTypes.FirstAsync(a => a.Id == id);

            if (assetType == null)
                throw new Exception("AssetType not found.");

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


        public async Task<AssetType> EditAssetType(AssetType assetType)
        {
            if (assetType == null)
                throw new Exception("AssetType not found.");

            _db.AssetTypes.Update(assetType);
            await _db.SaveChangesAsync();
            return assetType;
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
