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

        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    return View(await _sensorTypeServices.Get());
        //}


        //Get list of SensorTypes by Id
        [HttpGet]
        public async Task<IActionResult> Get(int Id)
        {
            return View(await _sensorTypeServices.Get(Id));
        }
    }
}
