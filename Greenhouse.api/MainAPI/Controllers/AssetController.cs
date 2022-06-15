using MainAPI.Data;
using MainAPI.DTO;
using MainAPI.HttpClientHelper;
using MainAPI.Models;
using MainAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MainAPI.Controllers
{
    //connect to swagger
    [ApiController]
    [Route("api/[controller]/[Action]")]

    public class AssetController : Controller
    {
        private readonly IAssetService _assetService;


        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }


        //Get Assets List
        [HttpGet]
        public async Task<List<AssetDTO>> GetAssets() =>
            await _assetService.GetAssets();


        //GetAsset ById
        [HttpGet]
        public async Task<AssetDTO> GetAssetById(int id) =>
            await _assetService.GetAssetById(id);


        //Create new asset
        [HttpPost]
        public async Task<AssetDTO> CreateAsset(Asset asset) =>
            await _assetService.CreateAsset(asset);


        //Edit asset
        [HttpPut]
        public async Task<AssetDTO> EditAsset(Asset asset) =>
            await _assetService.EditAsset(asset);


        //Delete Asset
        [HttpPut]
        public async Task<bool> ChangeState(int id) =>
            await _assetService.ChangeState(id);
    }
}
