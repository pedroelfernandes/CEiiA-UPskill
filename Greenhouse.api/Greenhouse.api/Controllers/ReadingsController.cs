using Greenhouse.api.Models;
using Greenhouse.api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.api.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ReadingsController : ControllerBase
    {
        private readonly GreenhouseService _greenhouseService;



        public ReadingsController(GreenhouseService greenhouseService)
        {
            _greenhouseService = greenhouseService;
        }



        [HttpGet]
        public async Task<List<Reading>> Get() => 
            await _greenhouseService.GetAsync();



        [HttpGet]
        public List<Reading> GetLast() =>
            _greenhouseService.GetLast();



        [HttpGet]
        public async Task<Reading> GetLastBySensorId(string id) =>
            await _greenhouseService.GetLastBySensorId(id);



        [HttpGet]
        public async Task<List<Reading>> GetLastValuesBySensorId(string id, int limit) =>
            await _greenhouseService.GetLastValuesBySensorId(id, limit);
    }
}
