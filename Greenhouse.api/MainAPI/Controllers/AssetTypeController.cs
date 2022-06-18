using MainAPI.DTO;
using MainAPI.HttpClientHelper;
using MainAPI.Models;
using MainAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MainAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[Action]")]

    public class AssetTypeController : Controller
    {
        private readonly IAssetTypeService _assetTypeService;
        public AssetTypeController(IAssetTypeService assetTypeService)
        {
            _assetTypeService = assetTypeService;
        }

        //Get AssetTypes List
        [HttpGet]
        public async Task<IEnumerable<AssetTypeDTO>> GetAssetTypes() => await _assetTypeService.GetAssetTypes();



        //GetAssetType ById
        [HttpGet]
        public async Task<AssetTypeDTO> GetAssetTypeById(int id) => await _assetTypeService.GetAssetTypeById(id);



        //Create new assetType
        [HttpPost]
        public async Task<AssetTypeDTO> CreateAssetType(AssetType assetType)
        {
            assetType.IsActive = true;
            return await _assetTypeService.CreateAssetType(assetType);
        }



        //Edit assetType
        [HttpPut]
        public async Task<AssetTypeDTO> EditAssetType(AssetType assetType)
        {
            return await _assetTypeService.EditAssetType(assetType.Id, assetType.Name, assetType.Description, assetType.IsActive);
        }



        //Delete Asset
        [HttpPut]
        public async Task<bool> ChangeStateAssetType(int id)
        {
            return await _assetTypeService.ChangeStateAssetType(id);
        }

    }
}
