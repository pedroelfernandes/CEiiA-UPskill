using MainAPI.DTO;
using MainAPI.HttpClientHelper;
using MainAPI.Models;
using MainAPI.Repositories.Interfaces;
using MainAPI.Services.Interfaces;

namespace MainAPI.Services.Implementations
{
    public class AssetService: IAssetService
    {
        private readonly IAssetRepository _assetRepository;


        public AssetService(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }

        //public Task<AssetDTO> CreateAsset(Asset asset)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<AssetDTO> DeleteAsset(int Id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<AssetDTO> EditAsset(int Id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<AssetDTO> GetAssetById(int Id)
        //{

        //    throw new NotImplementedException();
        //}

        //Create the service to send the full Assets list
        public async Task<IEnumerable<AssetDTO>> GetAssets(Enumerables.SortItem sort, Enumerables.OrderItem order)
        {
            //Creates a list of assets and send it to a DTO
            IEnumerable<Asset> assets = new List<Asset>();
            IEnumerable<AssetDTO> assetsDTO = new List<AssetDTO>();

            assets = await _assetRepository.GetAssets(sort, order);

            assetsDTO = assets.Select(asset => AssetDTO.ToDto(asset)).ToList();

            return assetsDTO;
        }
    }
}
