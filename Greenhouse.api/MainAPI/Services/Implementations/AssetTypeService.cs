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
        public async Task<List<AssetTypeDTO>> GetAssetTypes()
        {
            List<AssetType> assetTypes = await _assetTypeRepository.GetAssetTypes();

            return assetTypes.Select(assetType => AssetTypeDTO.ToDto(assetType)).ToList();
        }


        //transfer specific AssetType to DTO
        public async Task<AssetTypeDTO> GetAssetTypeById(int id)
        {
            //transfer the Asset with the specific Id from the repository to DTO
            AssetType tempassetType = await _assetTypeRepository.GetAssetTypeById(id);

            return AssetTypeDTO.ToDto(tempassetType);
        }


        //Transfer the CreateAsset content to DTO
        public async Task<AssetTypeDTO> CreateAssetType(AssetType assetType)
        {
            AssetType tempAssetType = await _assetTypeRepository.CreateAssetType(assetType);

            return AssetTypeDTO.ToDto(tempAssetType);
        }


        //Edit
        public async Task<AssetTypeDTO> EditAssetType(int id, string name, string description, bool active)
        {
            AssetType tempAssetType = await _assetTypeRepository.EditAssetType(id, name, description, active);

            return AssetTypeDTO.ToDto(tempAssetType);
        }


        //Inactivate Asset
        public async Task<bool> ChangeStateAssetType(int id) =>
            await _assetTypeRepository.ChangeStateAssetType(id);
    }
}
