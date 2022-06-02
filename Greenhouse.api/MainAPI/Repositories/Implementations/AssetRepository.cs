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

        //public Task<bool> CreateAsset(Asset asset)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> DeleteAsset(int Id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<Asset> GetAssetById(int id)
        //{
        //    return await _db.Assets.FirstOrDefaultAsync(a => a.Id == id);
        //}

        public async Task<IEnumerable<Asset>> GetAssets(Enumerables.SortItem sort, Enumerables.OrderItem order)
        {
            var assets = new List<Asset>();
            assets = await _db.Assets.ToListAsync();
            return assets;

        }
        //public Task<bool> EditAsset(int Id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
