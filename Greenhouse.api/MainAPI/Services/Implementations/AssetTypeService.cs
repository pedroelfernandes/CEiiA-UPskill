using MainAPI.DTO;
using MainAPI.HttpClientHelper;
using MainAPI.Models;
using MainAPI.Repositories.Interfaces;
using MainAPI.Services.Interfaces;

namespace MainAPI.Services.Implementations
{
    public class AssetTypeService : IAssetTypeService
    { 
        private readonly IAssetTypeRepository _assetTypeRepository;


        public AssetTypeService (IAssetTypeRepository assetTypeRepository)
        {
            _assetTypeRepository = assetTypeRepository;
        }


        //Creates list of AsssetTypes and send it to DTO
        public async Task<List<AssetTypeDTO>> GetAssetTypes() =>
            (await _assetTypeRepository.GetAssetTypes()).Select(assetType => AssetTypeDTO.ToDto(assetType)).ToList();


        //transfer specific AssetType to DTO
        public async Task<AssetTypeDTO> GetAssetTypeById(int id) =>
            //transfer the Asset with the specific Id from the repository to DTO
            AssetTypeDTO.ToDto(await _assetTypeRepository.GetAssetTypeById(id));


        //Transfer the CreateAsset content to DTO
        public async Task<AssetTypeDTO> CreateAssetType(AssetType assetType) =>
            AssetTypeDTO.ToDto(await _assetTypeRepository.CreateAssetType(assetType));


        //Edit
        public async Task<AssetTypeDTO> EditAssetType(AssetType assetType) =>
            AssetTypeDTO.ToDto(await _assetTypeRepository.EditAssetType(assetType));


        //Inactivate Asset
        public async Task<bool> ChangeStateAssetType(int id) =>
            await _assetTypeRepository.ChangeStateAssetType(id);
    }
}
