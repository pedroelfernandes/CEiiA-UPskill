using Greenhouse.web.Models;
using Greenhouse.web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
            return assetType == null ? NotFound() : View(assetType);
        }


        //Edit AssetType
        public async Task<IActionResult> EditAssetType(int id)
        {
            var assetType = await _assetTypeServices.GetAssetTypeById(id);
            return View(assetType);
        }


        [HttpPost]
        public async Task<IActionResult> EditAssetType(int id, AssetType assetType)
        {
            if (id != assetType.Id)
            {
                return BadRequest();
            }

            AssetType assetTypeResult;
            if (ModelState.IsValid)
            {
                assetTypeResult = await _assetTypeServices.EditAssetType(assetType);
                if (assetTypeResult != null)
                {
                    return RedirectToAction("GetAssetTypes");
                }
            }
            return View(await _assetTypeServices.GetAssetTypes());
        }


        //Change the status of the assetType(AssetType)
        [HttpGet]
        public async Task<IActionResult> ChangeStateAssetType(int id)
        {
            bool res = await _assetTypeServices.ChangeStateAssetType(id);

            if (!res)
                ModelState.AddModelError("Error001", "Error while deleting the record");

            return RedirectToAction("GetAssetTypes");
        }
    }
}
