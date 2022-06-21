using MainAPI.DTO;
using MainAPI.Models;
using MainAPI.Repositories.Interfaces;
using MainAPI.Services.Interfaces;

namespace MainAPI.Services.Implementations
{
    public class AssetService: IAssetService
    {
        private readonly IAssetRepository _assetRepository;

        private readonly IAssetTypeService _assetTypeService;

        private readonly IAssetSensorService _assetSensorService;


        public AssetService(IAssetRepository assetRepository, IAssetTypeService assetTypeService, IAssetSensorService assetSensorService)
        {
            _assetRepository = assetRepository;

            _assetTypeService = assetTypeService;

            _assetSensorService = assetSensorService;
        }


        //transform Assets list to a DTO object
        public async Task<List<AssetDTO>> GetAssets()
        {
            List<Asset> assets = await _assetRepository.GetAssets();

            foreach (Asset asset in assets)
                asset.Sensors = await _assetSensorService.GetAssetSensors(asset.Id);

            return assets.Select(asset => AssetDTO.ToDto(asset)).ToList();
        }
            

        public async Task<List<AssetDTO>> GetActiveAssets()
        {
            List<Asset> assets = await _assetRepository.GetActiveAssets();

            foreach (Asset asset in assets)
                asset.Sensors = await _assetSensorService.GetAssetSensors(asset.Id);

            return assets.Select(asset => AssetDTO.ToDto(asset)).ToList();
        }


        //transfer a specific Asset to DTO
        public async Task<AssetDTO> GetAssetById(int id)
        {
            Asset asset = await _assetRepository.GetAssetById(id);

            asset.Sensors = await _assetSensorService.GetAssetSensors(asset.Id);

            return AssetDTO.ToDto(await _assetRepository.GetAssetById(id));
        }
            

        //Transfer the CreateAsset content to DTO
        public async Task<AssetDTO> CreateAsset(Asset asset)
        {
            //Asset assetTemp = await _assetRepository.CreateAsset(asset);
            asset = await _assetRepository.CreateAsset(asset);

            //assetTemp.Sensors = await _assetSensorService.GetAssetSensors(assetTemp.Id);
            asset.Sensors = await _assetSensorService.GetAssetSensors(asset.Id);

            //return AssetDTO.ToDto(assetTemp);
            return AssetDTO.ToDto(asset);
        }
            

        //Edit
        public async Task<AssetDTO> EditAsset(Asset asset)
        {
            //Asset assetTemp = await _assetRepository.EditAsset(asset);
            asset = await _assetRepository.EditAsset(asset);

            //assetTemp.Sensors = await _assetSensorService.GetAssetSensors(assetTemp.Id);
            asset.Sensors = await _assetSensorService.GetAssetSensors(asset.Id);

            //return AssetDTO.ToDto(assetTemp);
            return AssetDTO.ToDto(asset);
        }
            

        //Inactivate Asset
        public async Task<bool> ChangeState(int id) =>
            await _assetRepository.ChangeState(id);            
    }
}
