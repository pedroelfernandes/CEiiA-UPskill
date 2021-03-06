using MainAPI.DTO;
using MainAPI.Models;
using MainAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MainAPI.Controllers
{
    //connect to swagger
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AssetController : Controller
    {
        private readonly IAssetService _assetService;
        private readonly IAssetSensorService _assetSensorService;


        public AssetController(IAssetService assetService, IAssetSensorService assetSensorService)
        {
            _assetService = assetService;
            _assetSensorService = assetSensorService;
        }


        //Get Assets List
        [HttpGet]
        public async Task<List<AssetDTO>> GetAssets() =>
            await _assetService.GetAssets();


        //GetAsset ById
        [HttpGet]
        public async Task<AssetDTO> GetAsset(int id) =>
            await _assetService.GetAssetById(id);


        //Create new asset
        [HttpPost]
        public async Task<AssetDTO> CreateAsset(Asset asset) =>
            await _assetService.CreateAsset(asset);


        //Edit asset
        [HttpPut]
        public async Task<AssetDTO> EditAsset(AssetDTO assetDTO) =>
            await _assetService.EditAsset(assetDTO);


        //Delete Asset
        [HttpPut]
        public async Task<bool> ChangeState(int id) =>
            await _assetService.ChangeState(id);


        //Add Sensor to Asset
        [HttpGet]
        public async Task<bool> AddAssetSensor(int assetId, int sensorId) =>
            await _assetSensorService.AddAssetSensor(assetId, sensorId);

        //Remove Sensor from Asset
        [HttpGet]
        public async Task<bool> RemoveAssetSensor(int assetId, int sensorId) =>
            await _assetSensorService.RemoveAssetSensor(assetId, sensorId);
    }
}
