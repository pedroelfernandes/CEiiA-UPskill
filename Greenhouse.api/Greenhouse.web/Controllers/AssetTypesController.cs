using Greenhouse.web.Models;
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


        //Get Full List of AssetTypes

        [HttpGet]
        public async Task<IActionResult> GetAssetTypes()
        {
            return View(await _assetTypeServices.GetAssetTypes());
        }


        //Create new AssetType

        public IActionResult CreateAssetType()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAssetType(AssetType assetType)
        {
            AssetType assetTypeResult;

            if (ModelState.IsValid)
            {
                assetTypeResult = await _assetTypeServices.CreateAssetType(assetType);

                if (assetTypeResult != null)
                {
                    return RedirectToAction("GetAssetTypes", assetType);
                }
            }

            return View(assetType);
        }


        //Get AssetType by Id

        [HttpGet("id")]
       public async Task<IActionResult> GetAssetTypeById(int id)
        {
            var assetType = await _assetTypeServices.GetAssetTypeById(id);
            return assetType == null ? NotFound(): View(assetType);
        }


        //Edit AssetType
        public IActionResult EditAssetType()
        {
            return View();
        }

        [HttpPut("id")]
        public async Task<IActionResult> EditAssetType(AssetType assetType)
        {
            AssetType assetTypeResult;
            if (ModelState.IsValid)
            {
                assetTypeResult = await _assetTypeServices.EditAssetType(assetType);

                if (assetTypeResult != null)
                {
                    return RedirectToAction("GetAssetTypes", assetType);
                }
            }
            return View(assetType);
        }
    }
}
