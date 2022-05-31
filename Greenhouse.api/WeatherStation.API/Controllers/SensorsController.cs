using Microsoft.AspNetCore.Mvc;
using WeatherStation.api.DTOs;
using WeatherStation.api.Services.Interfaces;

namespace WeatherStation.api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SensorsController : Controller
    {
        private readonly ISensorService _sensorService;


        public SensorsController(ISensorService sensorService)
        {
            _sensorService = sensorService;
        }


        public async Task<SensorDTO> GetSensorById(string id) =>
            await _sensorService.GetSensorById(id);
    }
}
