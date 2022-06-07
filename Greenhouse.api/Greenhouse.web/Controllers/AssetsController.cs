using Greenhouse.web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.web.Controllers
{
    [Route("[controller]/[action]")]
    public class AssetsController : Controller
    {

        private readonly IAssetServices _assetServices;
        public AssetsController(IAssetServices assetServices)
        {
            _assetServices = assetServices;
        }


        [HttpGet]
        public async Task<IActionResult> GetAssets()
        {
            return View(await _assetServices.GetAssets());
        }

    }
}
