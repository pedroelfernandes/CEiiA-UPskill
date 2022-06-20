using Greenhouse.web.Models;
using Greenhouse.web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.web.Controllers
{
    public class SensorsController : Controller
    {
        private readonly ISensorServices _sensorServices;

        public SensorsController (ISensorServices sensorServices)
        {
            _sensorServices = sensorServices;
        }


        // Get Sensors List
        // 
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Sensor> sensors = await _sensorServices.Get();
            return View(sensors);
        }


        //Get Sensors by Id

        [HttpGet("id")]
        public async Task<IActionResult> GetSensorsById(int id)
        {
            var sensor = await _sensorServices.GetSensorById(id);
            return sensor == null ? NotFound() : View(sensor);
        }



        // create new Sensor

        public IActionResult Create()
        {
            return View();
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


        //Edit Sensor
        public async Task<IActionResult> Edit(int id)
        {
            var sensor = await _sensorServices.GetSensorById(id);
            return View(sensor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Sensor sensor)
        {
            if (id != sensor.Id)
            {
                return BadRequest();
            }

            Sensor sensorResult;
            if (ModelState.IsValid)
            {
                sensorResult = await _sensorServices.Edit(sensor);

                if (sensorResult != null)
                {
                    return RedirectToAction("Get");
                }
            }
            return View(await _sensorServices.Get());
        }

        //Change state from true to false and vice versa for sensors
        [HttpGet]
        public async Task<IActionResult> ChangeState(int id)
        {
            bool res = await _sensorServices.ChangeState(id);

            if (!res)
                ModelState.AddModelError("Error001", "Error while deleting the record");

            return RedirectToAction("Get");
        }
    }
}
