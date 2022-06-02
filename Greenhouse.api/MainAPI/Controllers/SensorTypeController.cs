using MainAPI.DTO;
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

        public async Task<SensorTypeDTO> Get(int id) => await _sensorTypeService.Get(id);
    }
}
