using MainAPI.DTO;
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
        public async Task<SensorDTO> Get(int id) => await _sensorService.Get(id);


        // Edit sensor information
        [HttpPut]
        public async Task<SensorDTO> Edit(int id, string name, string description,
            string unit, int urlId, string company, int sensorTypeId) =>
            await _sensorService.Edit(id, name, description, unit, urlId, company, sensorTypeId);


        // Change state between active and inactive
        [HttpPut]
        public async Task<bool> ChangeState(int id) =>
            await _sensorService.ChangeState(id);
    }
}
