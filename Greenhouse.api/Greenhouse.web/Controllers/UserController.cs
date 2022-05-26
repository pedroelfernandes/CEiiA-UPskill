
using Greenhouse.web.Models;
using Greenhouse.web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.web.Controllers
{
    public class UserController : Controller
    {

        //private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;

        public UserController( IConfiguration configuration)
        {
            
            _configuration = configuration;
        }


        public async Task<IActionResult> UserDashboard1(string apiId, string sensorId)
        {
            return View(await ReadingServices.GetLastSensorValue(apiId, sensorId, _configuration));
        }
    }
}
