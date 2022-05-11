using Microsoft.AspNetCore.Mvc;
using WeatherStation.api.Models;
using WeatherStation.api.Services;

namespace WeatherStation.api.Controllers
{
    [ApiController]
    [Route("api/ReadingsController")]
    public class ReadingsController : Controller
    {
        private readonly WeatherStationService _weatherStationService;


        public ReadingsController(WeatherStationService weatherStationService) => _weatherStationService = weatherStationService;


        [HttpGet]
        public async Task<List<Reading>> Get() => await _weatherStationService.GetAsync();


        [HttpGet]
        [Route("GetLast")]
        public List<Reading> GetLast() => _weatherStationService.GetLast();
    }
}
