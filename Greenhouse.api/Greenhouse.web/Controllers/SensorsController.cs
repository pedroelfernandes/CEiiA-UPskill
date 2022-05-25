using Greenhouse.web.Data;
using Greenhouse.web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.web.Controllers
{
    public class SensorsController : Controller
    {


        private readonly IConfiguration _configuration;

        public SensorsController(IConfiguration configuration)
        {

            _configuration = configuration;
        }


        // HTTP Method: GET       
        public IActionResult Get()
        {
            return View();
        }


        // Method that retrives the list of every sensor recorded within an API from wich the user selected through its "apiId" 
        public async Task<IActionResult> GetAPISensors(string apiId)
        {
            ViewBag.apiId = apiId;
            return View(await Greenhouse.web.Services.SensorServices.GetAPISensors("2", _configuration));
        }
    }
}
