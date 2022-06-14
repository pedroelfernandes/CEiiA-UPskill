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

        // Method that retrives the list of every sensor recorded within an API from wich the user selected through its "apiId" 
        //public async Task<IActionResult> GetAPISensors(string apiId)
        //{
        //    ViewBag.apiId = apiId;
        //    return View(await Greenhouse.web.Services.SensorServices.GetAPISensors("2", _configuration));
        //}
    }
}
