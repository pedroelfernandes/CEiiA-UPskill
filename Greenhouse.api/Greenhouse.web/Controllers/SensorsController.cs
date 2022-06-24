using Greenhouse.web.Models;
using Greenhouse.web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public async Task<IActionResult> Get()
        {
            List<Sensor> sensors = await _sensorServices.Get();
            return View(sensors);
        }


        //Get Sensor by Id

        [HttpGet("id")]
        public async Task<IActionResult> GetSensorById(int id)
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
            List<SensorType> sensorTypes = await _sensorTypeServices.Get();
            ViewBag.SensorTypeId = new SelectList(sensorTypes, "Id", "Name");
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
            return View(sensor);
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
