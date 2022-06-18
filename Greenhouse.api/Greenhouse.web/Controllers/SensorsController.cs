using Greenhouse.web.Models;
using Greenhouse.web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.web.Controllers
{
    public class SensorsController : Controller
    {
        private readonly ISensorServices _sensorServices;
        private readonly ISensorTypeServices _sensorTypeServices;

        public SensorsController (ISensorServices sensorServices, ISensorTypeServices sensorTypeServices)
        {
            _sensorServices = sensorServices;
            _sensorTypeServices = sensorTypeServices;
        }


        // Get Sensors List
        // 
        [HttpGet]
        public async Task<IActionResult> GetSensors()
        {
            IEnumerable<Sensor> sensors = await _sensorServices.GetSensors();
            return View(sensors);
        }



        [HttpPost]
        public async Task<IActionResult> Create(Sensor sensor)
        {
            Sensor sensorResult;

            if (ModelState.IsValid)
            {
                sensorResult = await _sensorServices.Create(sensor);

                if (sensorResult != null)
                {
                    return RedirectToAction("Get", sensor);
                }
            }
            return View(sensor);
        }
    }
}
