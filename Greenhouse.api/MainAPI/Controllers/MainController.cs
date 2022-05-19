using MainAPI.DTO;
using MainAPI.Models;
using MainAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MainAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly APIRepository _apiRepository;


        public MainController(IConfiguration configuration, APIRepository apiRepository)
        {
            _configuration = configuration;
            _apiRepository = apiRepository;
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


        [HttpGet]
        public async Task<List<SensorDTO>> GetAPISensors(string id) =>
            (List<SensorDTO>)await MainAPI.Services.Services.GetAPISensors(id, _configuration);


        [HttpGet]
        public async Task<List<APIDTO>> GetAPIs() =>
            (List<APIDTO>)await MainAPI.Services.Services.GetAPIs(_apiRepository);
    }
}
