using MainAPI.DTO;
using MainAPI.Models;
using MainAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MainAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SensorController : Controller
    {
        private readonly ISensorService _sensorService;


        public SensorController(ISensorService sensorService)
        {
            _sensorService = sensorService;
        }


        [HttpGet]
        public async Task<SensorDTO> Get(int id) =>
            await _sensorService.Get(id);


        // Edit sensor information
        [HttpPut]
        public async Task<SensorDTO> Edit(Sensor sensor) =>
            await _sensorService.Edit(sensor);


        // Change state between active and inactive
        [HttpPut]
        public async Task<bool> ChangeState(int id) =>
            await _sensorService.ChangeState(id);


        [HttpGet]
        public async Task<bool> CheckForNewSensors() =>
            await _sensorService.CheckForNewSensors();


        [HttpGet]
        public async Task<bool> CheckForGenericSensors() =>
            await _sensorService.CheckForGenericSensors();
    }
}
