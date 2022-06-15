using Greenhouse.web.Models;
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

        //Get Full List of SensorTypes

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<SensorType> sensorTypes = await _sensorTypeServices.Get();
            return View(sensorTypes);
        }


        //Get list of SensorTypes by Id
        [HttpGet]
        public async Task<IActionResult> Get(int Id)
        {
            return View(await _sensorTypeServices.GetById(Id));
        }


        // Crete a new type of sensor
        public async Task<IActionResult> Create (SensorType sensorType)
        {
            SensorType sensorTypeResult;

            if (ModelState.IsValid)
            {
                sensorTypeResult = await _sensorTypeServices.Create(sensorType);

                if(sensorTypeResult != null)
                {
                    return RedirectToAction("Get", sensorType);
                }
            }
            return View(sensorType);
        }
    }
}
