using Greenhouse.web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.web.Controllers
{
    [Route("[controller]/[action]")]
    public class SensorTypesController : Controller
    {

        private readonly ISensorTypeServices _sensorTypeServices;
        public SensorTypesController(ISensorTypeServices sensorTypeServices)
        {
            _sensorTypeServices = sensorTypeServices;
        }

        //public async Task<IEnumerable<AssetType>> GetAssetTypes() => await _assetTypeServices.GetAssetTypes();

        //Get Full List of AssetTypes

        [HttpGet]
        public async Task<IActionResult> GetSensorTypes()
        {
            return View(await _sensorTypeServices.GetSensorTypes());
        }

    }
}
