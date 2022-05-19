using Microsoft.AspNetCore.Mvc;
using WeatherStation.api.DTOs;
using WeatherStation.api.Models;
using WeatherStation.api.Services;

namespace WeatherStation.api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ReadingsController : Controller
    {
        private readonly WeatherStationService _weatherStationService;


        public ReadingsController(WeatherStationService weatherStationService) => _weatherStationService = weatherStationService;


        [HttpGet]
        public async Task<List<Reading>> Get() => await _weatherStationService.GetAsync();


        [HttpGet]
        public List<ReadingDTO> GetLast() => _weatherStationService.GetLast();


        [HttpGet]
        public async Task<ReadingDTO> GetLastBySensorId(string id) =>
            await _weatherStationService.GetLastBySensorId(id);


        [HttpGet]
        public async Task<List<ReadingDTO>> GetLastValuesBySensorId(string id, int limit) =>
            await _weatherStationService.GetLastValuesBySensorId(id, limit);


        [HttpGet]
        public List<SensorDTO> GetSensors() =>
            _weatherStationService.GetSensors();
    }
}
