using Greenhouse.web.Models;
using Greenhouse.web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.web.Controllers
{
    [Route("[controller]/[action]")]
    public class AssetsController : Controller
    {

        private readonly IAssetServices _assetServices;
        //private readonly IAssetTypeServices _assetTypeServices;
        public AssetsController(IAssetServices assetServices)
        //public AssetsController(IAssetServices assetServices, IAssetTypeServices assetTypeServices)
        {
            _assetServices = assetServices;
           // _assetTypeServices = assetTypeServices;
        }


        [HttpGet]
        public async Task<IActionResult> GetAssets()
        {
            IEnumerable<Asset> assets = await _assetServices.GetAssets();
            return View(assets);
        }

        ////Create new Asset

        //public IActionResult CreateAsset()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateAsset(Asset asset)
        //{
        //    Asset assetResult;

        //    if (ModelState.IsValid)
        //    {
        //        assetResult = await _assetServices.CreateAsset(asset);

        //        if (assetResult != null)
        //        {
        //            return RedirectToAction("GetAsset", asset);
        //        }
        //    }

        //    return View(asset);
        //}

    }
}
