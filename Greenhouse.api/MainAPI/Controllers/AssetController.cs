using MainAPI.Data;
using MainAPI.DTO;
using MainAPI.HttpClientHelper;
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

        //getlist of Assets
        [HttpGet]
        public async Task<IEnumerable<AssetDTO>> GetAssets()
        {
            return await _assetService.GetAssets(Enumerables.SortItem.ASC, Enumerables.OrderItem.Id);
        }


        ////Method Get Asset ById
        //[HttpGet("id")]

        //async Task<AssetDTO> GetAssetById()
        //{
        //    return await _assetService.GetAssetById(Id);
        //}
    }
}
