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


        public async Task<IActionResult> Index()
        {
            IEnumerable<Reading> readings = await Reading.GetReadings(_configuration.GetValue<string>("URL"));
            return View(readings);
        }

    }
}
