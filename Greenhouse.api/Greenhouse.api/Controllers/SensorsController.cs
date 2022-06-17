using Greenhouse.api.DTOs;
using Greenhouse.api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.api.Controllers
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


        [HttpGet]
        [Authorize]
        public async Task<SensorDTO> GetSensorById(string id) =>
            await _sensorService.GetSensorById(id);


        [HttpGet]
        [Authorize]
        public async Task<IReadOnlyList<SensorDTO>> GetAllSensors() =>
            await _sensorService.GetAllSensors();
    }
}
