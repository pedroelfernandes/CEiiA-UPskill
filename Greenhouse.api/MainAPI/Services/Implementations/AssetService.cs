using MainAPI.DTO;
using MainAPI.HttpClientHelper;
using MainAPI.Models;
using MainAPI.Repositories.Interfaces;
using MainAPI.Services.Interfaces;
using System.Linq;

namespace MainAPI.Services.Implementations
{
    public class AssetService: IAssetService
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IAssetTypeRepository _assetTypeRepository;

        public AssetService(IAssetRepository assetRepository, IAssetTypeRepository assetTypeRepository)
        {
            _assetRepository = assetRepository;
            _assetTypeRepository = assetTypeRepository;
        }



        //transform Assets list to a DTO object
        public async Task<IEnumerable<AssetDTO>> GetAssets()
        {
            //Creates a list of assets and send it to a DTO
            IEnumerable<Asset> assets = await _assetRepository.GetAssets();

            foreach (Asset asset in assets)
            {
                asset.AssetType = await _assetTypeRepository.GetAssetTypeById(asset.AssetTypeId);
            }
           
            return assets.Select (x =>AssetDTO.ToDto(x)).ToList();
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

        ////Edit
        //public async Task<AssetDTO> EditAsset(int id, string name, string company, string location, DateTime creationDate, AssetTypeId assetTypeId, bool active)
        //{
        //    Asset tempAsset = await _assetRepository.EditAsset(id, name, company, location, creationDate, assetTypeId, active);
        //    return AssetDTO.ToDto(tempAsset);
        //}

        //Edit
        public async Task<AssetDTO> EditAsset(Asset asset)
        {
            Asset tempAsset = await _assetRepository.EditAsset(asset);
            return AssetDTO.ToDto(tempAsset);
        }

        //Inactivate Asset
        public async Task<bool> ChangeState(int id)
        {
            return await _assetRepository.ChangeState(id);            
        }





    }
}
