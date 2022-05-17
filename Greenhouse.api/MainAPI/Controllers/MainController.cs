using MainAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MainAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : Controller
    {
        private readonly IConfiguration _configuration;



        public MainController(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        [HttpGet]
        public async Task<List<Reading>> GetLastByAPI(string id) =>
            (List<Reading>)await MainAPI.Services.Services.GetLastByAPI(id, _configuration);



        [HttpGet]
        public async Task<Reading> GetLastByAPIBySensorId(string id, int sensorId) =>
            (Reading)await MainAPI.Services.Services.GetLastByAPIBySensorId(id, sensorId, _configuration);


        [HttpGet]
        public async Task<List<Reading>> GetLastValuesBySensorId(string id, int sensorId, int limit) => 
            (List<Reading>)await MainAPI.Services.Services.GetLastValuesBySensorId(id, sensorId, limit, _configuration);
    }
}
