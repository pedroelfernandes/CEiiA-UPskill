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

        private readonly ISensorTypeServices _sensorTypeServices;

        private readonly IReadingServices _readingServices;


        public DashboardController(IAssetServices assetServices, IAssetTypeServices assetTypeServices, 
            ISensorTypeServices sensorTypeServices, IReadingServices readingServices)
        {
            _assetServices = assetServices;

            _assetTypeServices = assetTypeServices;

            _sensorTypeServices = sensorTypeServices;

            _readingServices = readingServices;
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


        public async Task<JsonResult> GetSensorsCount(int assetId)
        {
            List<Sensor> sensors = (await _assetServices.GetAssetById(assetId)).Sensors;

            List<SensorType> sensorTypes = await _sensorTypeServices.Get();

            List<Counter> counters = new();

            foreach (SensorType sensorType in sensorTypes)
            {
                int count = sensors.Where(s => s.SensorTypeId == sensorType.Id).Count();

                if (count != 0)
                {
                    Counter counter = new Counter { Type = sensorType.Name, Count = count};

                    counters.Add(counter);
                }
            }

            return Json(counters);
        }


        public async Task<JsonResult> GetSensorReadings(int sensorId)
        {
            List<Reading> readings = await _readingServices.GetSensorReadings(sensorId);

            return Json(readings.Select(r => new { Value = r.Value, Date = r.ReadDate }));
        }


        public async Task<JsonResult> GetSensorReadingsBetweenDates(int sensorId, DateTime startDate, DateTime endDate)
        {
            List<Reading> readings = await _readingServices.GetSensorReadingsBetweenDates(sensorId, startDate, endDate);

            return Json(readings.Select(r => new { Value = r.Value, Date = r.ReadDate }));
        }
    }


    public struct Counter
    {
        public string Type { get; set; }


        public int Count { get; set; }
    }
}
