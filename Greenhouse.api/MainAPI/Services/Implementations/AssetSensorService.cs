using MainAPI.Models;
using MainAPI.Repositories.Interfaces;
using MainAPI.Services.Interfaces;

namespace MainAPI.Services.Implementations
{
    public class AssetSensorService : IAssetSensorService
    {
        private readonly IAssetSensorRepository _assetSensorRepository;


        public AssetSensorService(IAssetSensorRepository assetSensorRepository)
        {
            _assetSensorRepository = assetSensorRepository;
        }


        public async Task<List<AssetSensor>> GetAssetSensors(int assetId) =>
            await _assetSensorRepository.GetAssetSensors(assetId);
    }
}
