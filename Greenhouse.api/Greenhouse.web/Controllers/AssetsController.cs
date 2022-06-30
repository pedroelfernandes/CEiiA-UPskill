using Greenhouse.web.Models;
using Greenhouse.web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Greenhouse.web.Controllers
{
    [Route("[controller]/[action]")]
    public class AssetsController : Controller
    {
        private readonly IAssetServices _assetServices;

        private readonly IAssetTypeServices _assetTypeServices;

        private readonly ISensorServices _sensorServices;


        public AssetsController(IAssetServices assetServices, IAssetTypeServices assetTypeServices, ISensorServices sensorServices)
        {
            _assetServices = assetServices;
            _assetTypeServices = assetTypeServices;
            _sensorServices = sensorServices;
        }



        //Get full list of Assets
        [HttpGet]
        public async Task<IActionResult> GetAssets()
        {
            return View(await _assetServices.GetAssets());
        }


        //Create new Asset
        public async Task<IActionResult> CreateAsset()
        {
            List<AssetType> assets = await _assetTypeServices.GetAssetTypes();
            ViewBag.AssetTypeId = new SelectList(assets, "Id", "Name");
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


        //Get Asset by Id
        [HttpGet("id")]
        public async Task<IActionResult> GetAssetById(int id)
        {
            var asset = await _assetServices.GetAssetById(id);
            return asset == null ? NotFound() : View(asset);
        }


        //Edit Asset
        public async Task<IActionResult> EditAsset(int id)
        {
            var asset = await _assetServices.GetAssetById(id);
            List<AssetType> assets = await _assetTypeServices.GetAssetTypes();
            ViewBag.AssetTypeId = new SelectList(assets, "Id", "Name");
            return View(asset);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsset(int id, Asset asset)
        {
            if (id != asset.Id)
            {
                return BadRequest();
            }

            Asset assetResult;
            if (ModelState.IsValid)
            {
                assetResult = await _assetServices.EditAsset(asset);
                if (assetResult != null)
                {
                    return RedirectToAction("GetAssets");
                }
            }
            return View(await _assetServices.GetAssets());
        }


        //Change the status of the asset(Asset)
        [HttpGet]
        public async Task<IActionResult> ChangeStateAsset(int id)
        {
            bool res = await _assetServices.ChangeStateAsset(id);

            if (!res)
                ModelState.AddModelError("Error001", "Error while deleting the record");

            return RedirectToAction("GetAssets");
        }


        [HttpGet]
        public async Task<IActionResult> ManageSensors(int id)
        {
            TempData["AssetId"] = id;
            List<Sensor> sensors = (await _assetServices.GetAssetById(id)).Sensors;
            List<Sensor> sensorList = await _sensorServices.Get();

            //sensorList = sensorList.Except(sensors).ToList();
            Sensor sensorToRemove = new();
            foreach (Sensor sensor in sensors)
            {
                sensorList.Remove(sensorList.Find(s => s.Id == sensor.Id));
            }


            ViewBag.Sensors = sensors;
            ViewBag.AssetId = id;
            ViewBag.MissingSensors = sensorList;

            return View(id);
        }

        [HttpGet]
        public async Task<IActionResult> RemoveSensor(int assetId, int sensorId)
        {
            bool res = await _assetServices.RemoveAssetSensor(assetId, sensorId);

            return RedirectToAction($"ManageSensors",new { id = assetId});
        }


        [HttpGet]
        public async Task<IActionResult> AddSensor(int assetId, int sensorId)
        {
            bool res = await _assetServices.AddAssetSensor(assetId, sensorId);

            return RedirectToAction($"ManageSensors", new { id = assetId });
        }
    }
}
