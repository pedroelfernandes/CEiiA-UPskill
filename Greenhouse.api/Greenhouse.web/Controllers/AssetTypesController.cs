using Greenhouse.web.Models;
using Greenhouse.web.Services;
using Greenhouse.web.Services.Implementations;
using Greenhouse.web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.web.Controllers
{
    [Route("[controller]/[action]")]
    public class AssetTypesController : Controller
    {

        private readonly IAssetTypeServices _assetTypeServices;
        public AssetTypesController(IAssetTypeServices assetTypeServices)
        {
            _assetTypeServices = assetTypeServices;
        }

        //public async Task<IEnumerable<AssetType>> GetAssetTypes() => await _assetTypeServices.GetAssetTypes();

        //Get Full List of AssetTypes

        [HttpGet]
        public async Task<IActionResult> GetAssetTypes()
        {
            return View(await _assetTypeServices.GetAssetTypes());
        }
    }
}
