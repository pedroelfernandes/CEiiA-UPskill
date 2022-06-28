using Greenhouse.web.Models;
using Greenhouse.web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;

namespace Greenhouse.web.Controllers
{
    [Route("[controller]/[action]")]
    public class DashboardController : Controller
    {
        private readonly IAssetServices _assetServices;

        private readonly IAssetTypeServices _assetTypeServices;


        public DashboardController(IAssetServices assetServices, IAssetTypeServices assetTypeServices)
        {
            _assetServices = assetServices;

            _assetTypeServices = assetTypeServices;
        }


        public async Task<IActionResult> Index() =>
            View(await _assetServices.GetAssets());


        public async Task<JsonResult> GetAssetTypes()
        {
            List<AssetType> assetTypes = await _assetTypeServices.GetAssetTypes();
            return Json(assetTypes.Select(a => a.Name));
        }

        public async Task<JsonResult> GetAssetsCount()
        {
            List<Asset> assets = await _assetServices.GetAssets();

            List<AssetType> assetTypes = await _assetTypeServices.GetAssetTypes();

            List<Counter> counters = new();

            foreach (AssetType assetType in assetTypes)
            {
                int count = assets.Where(a => a.AssetTypeId == assetType.Id).Count();

                if (count != 0)
                {
                    Counter counter = new Counter { Type = assetType.Name, Count = count };

                    counters.Add(counter);
                }
            }

            return Json(counters);
        }
    }


    public struct Counter
    {
        public string Type { get; set; }


        public int Count { get; set; }
    }
}
