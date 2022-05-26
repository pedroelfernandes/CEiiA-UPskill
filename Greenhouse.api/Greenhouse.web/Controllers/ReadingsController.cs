using Greenhouse.web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.web.Controllers
{
    public class ReadingsController : Controller

    {
        private readonly IConfiguration _configuration;

        public ReadingsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        //NEED TO DELETE THIS METHOD, MAYBE
        public async Task<IActionResult> Index()
        {
            IEnumerable<Reading> readings = await Reading.GetReadings(_configuration.GetValue<string>("URL"));
            return View(readings);
        }


        // Method that retrieves the last value from the API from wich the user selected through its "apiId"
        [HttpGet]
        public async Task<IActionResult> GetLastByAPI(string apiId)
            => View(await Greenhouse.web.Services.ReadingServices.GetLastByAPI(apiId, _configuration));


        // Method that retrieves the last value from a specific sensor from the API from wich the user selected through its "apiId" and "sensorId"
        [HttpGet]
        public async Task<IActionResult> GetLastSensorValue(string apiId, string sensorId)
            => View(await Greenhouse.web.Services.ReadingServices.GetLastSensorValue(apiId, sensorId, _configuration));


        // Method that retrives the last specific values from a specific sensor from the API from wich the user selected through its "apiId" and "sensorId",
        // limited results shown are also defined by the user
        [HttpGet]
        public async Task<IActionResult> GetLastValuesBySensorId(string apiId, string sensorId, string limit)
            => View(await Greenhouse.web.Services.ReadingServices.GetLastValuesBySensorId(apiId, sensorId, limit, _configuration));
    }
}
