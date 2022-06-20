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

        //Get Full List of SensorType

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<SensorType> sensorTypes = await _sensorTypeServices.Get();
            return View(sensorTypes);
        }


        //Get SensorType by Id
        [HttpGet ("id")]
        public async Task<IActionResult> GetSensorTypeById(int id)
        {
            var sensorType = await _sensorTypeServices.GetSensorTypeById(id);
            return sensorType == null ? NotFound() : View(sensorType);
        }


        // Create a new type of sensor

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
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


        // Edit SensorType

        public async Task<IActionResult> Edit(int id)
        {
            var sensorType = await _sensorTypeServices.GetSensorTypeById(id);
            return View(sensorType);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SensorType sensorType)
        {
            if(id != sensorType.Id)
            {
                return BadRequest();
            }

            SensorType sensorTypeResult;

            if (ModelState.IsValid)
            {
                sensorTypeResult = await _sensorTypeServices.Edit(sensorType);

                if (sensorTypeResult != null)
                {
                    return RedirectToAction("Get");
                }
            }
            return View(await _sensorTypeServices.Get());
        }


        //Change state from true to false and vice versa for sensor types
        [HttpGet]
        public async Task<IActionResult> ChangeState(int id)
        {
            bool res = await _sensorTypeServices.ChangeState(id);

            if (!res)
                ModelState.AddModelError("Error001", "Error while deleting the record");

            return RedirectToAction("Get");
        }
    }
}
