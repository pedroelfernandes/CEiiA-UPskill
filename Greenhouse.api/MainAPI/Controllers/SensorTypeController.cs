using MainAPI.DTO;
using MainAPI.Models;
using MainAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MainAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SensorTypeController : Controller
    {
        private readonly ISensorTypeService _sensorTypeService;


        public SensorTypeController(ISensorTypeService sensorTypeService)
        {
            _sensorTypeService = sensorTypeService;
        }


        [HttpGet]
        public async Task<List<SensorTypeDTO>> Get() => 
            await _sensorTypeService.Get();


        [HttpGet]
        public async Task<SensorTypeDTO> GetSensorTypeById(int id) => 
            await _sensorTypeService.GetSensorTypeById(id);

        // Create a new sensor type
        [HttpPost]
        public async Task<SensorTypeDTO> Create(SensorType sensorType) =>
            await _sensorTypeService.Create(sensorType);


        // Edit sensor type information
        [HttpPut]
        public async Task<SensorTypeDTO> Edit(SensorType sensorType) =>
            await _sensorTypeService.Edit(sensorType);


        // Change state from active to inactive
        [HttpPut]
        public async Task<bool> ChangeState(int id) =>
            await _sensorTypeService.ChangeState(id);
    }
}
