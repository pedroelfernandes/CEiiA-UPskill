using Greenhouse.web.Models;
using Greenhouse.web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.web.Controllers
{
    [Route("[controller]/[action]")]
    public class AssetsController : Controller
    {

        private readonly IAssetServices _assetServices;
        private readonly IAssetTypeServices _assetTypeServices;
        public AssetsController(IAssetServices assetServices, IAssetTypeServices assetTypeServices)
        {
            _assetServices = assetServices;
            _assetTypeServices = assetTypeServices;
        }


        [HttpGet]
        public async Task<IActionResult> GetAssets()
        {
            IEnumerable<Asset> assets = await _assetServices.GetAssets();
            return View(assets);
        }

    }
}
