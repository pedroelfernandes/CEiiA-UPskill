using Greenhouse.web.Models;
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


        //Get full list of Assets

        [HttpGet]
        public async Task<IActionResult> GetAssets()
        {
            return View(await _assetServices.GetAssets());
        }


        //Create new Asset
        public IActionResult CreateAsset()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsset(Asset asset)
        {
            Asset assetResult;

            if (ModelState.IsValid)
            {
                assetResult = await _assetServices.CreateAsset(asset);

                if (assetResult != null)
                {
                    return RedirectToAction("GetAssets", asset);
                }
            }
            return View(asset);
        }

    }
}
