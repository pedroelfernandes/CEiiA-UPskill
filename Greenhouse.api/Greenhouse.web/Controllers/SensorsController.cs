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

    }
}
