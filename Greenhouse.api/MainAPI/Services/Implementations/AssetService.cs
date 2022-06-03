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
        private bool tempAsset;

        public AssetService(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }



        //transform Assets list to a DTO object
        public async Task<IEnumerable<AssetDTO>> GetAssets(Enumerables.SortItem sort, Enumerables.OrderItem order)
        {
            //Creates a list of assets and send it to a DTO
            IEnumerable<Asset> assets = new List<Asset>();
            IEnumerable<AssetDTO> assetsDTO = new List<AssetDTO>();

            assets = await _assetRepository.GetAssets(sort, order);

            assetsDTO = assets.Select(asset => AssetDTO.ToDto(asset)).ToList();

            return assetsDTO;
        }


        //transfer a specific Asset to DTO
        public async Task<AssetDTO> GetAssetById(int Id)
        {

            //transfer the Asset with the specific Id from the repository to DTO
            Asset tempasset = await _assetRepository.GetAssetById(Id);
            return AssetDTO.ToDto(tempasset);
        }


        //Transfer the CreateAsset content to DTO
        public async Task<AssetDTO> CreateAsset(Asset asset)
        {
            Asset tempAsset = await _assetRepository.CreateAsset(asset);
            return AssetDTO.ToDto(tempAsset);
        }

        //Edit
        public async Task<AssetDTO> EditAsset(int id, string name, string company, string location, DateTime creationDate, AssetType assetType, bool active)
        {
            Asset tempAsset = await _assetRepository.EditAsset(id, name, company, location, creationDate, assetType, active);
            return AssetDTO.ToDto(tempAsset);
        }


        //Inactivate Asset
        public async Task<bool> ChangeState(int id)
        {
            return await _assetRepository.ChangeState(id);            
        }





    }
}
