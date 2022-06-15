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
        private readonly IAssetTypeService _assetTypeService;


        public AssetService(IAssetRepository assetRepository, IAssetTypeService assetTypeService)
        {
            _assetRepository = assetRepository;
            _assetTypeService = assetTypeService;
        }


        //transform Assets list to a DTO object
        public async Task<List<AssetDTO>> GetAssets() =>
            (await _assetRepository.GetAssets()).ToList().Select(asset => AssetDTO.ToDto(asset)).ToList();


        //transfer a specific Asset to DTO
        public async Task<AssetDTO> GetAssetById(int Id) => 
            AssetDTO.ToDto(await _assetRepository.GetAssetById(Id));



        //Transfer the CreateAsset content to DTO
        public async Task<AssetDTO> CreateAsset(Asset asset)
        {
            AssetDTO tempAsset = AssetDTO.ToDto(await _assetRepository.CreateAsset(asset));
            
            //tempAsset.AssetType = await _assetTypeService.GetAssetTypeById(tempAsset.AssetTypeId);
            
            return tempAsset;
        }


        //Edit
        public async Task<AssetDTO> EditAsset(Asset asset)
        {
            AssetDTO tempAsset = AssetDTO.ToDto(await _assetRepository.EditAsset(asset));
            
            //tempAsset.AssetType = await _assetTypeService.GetAssetTypeById(tempAsset.AssetTypeId);
            
            return tempAsset;
        }


        //Inactivate Asset
        public async Task<bool> ChangeState(int id)
        {
            return await _assetRepository.ChangeState(id);            
        }
    }
}
