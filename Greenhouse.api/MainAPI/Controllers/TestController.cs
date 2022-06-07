using MainAPI.Models;
using MainAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MainAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TestController : Controller
    {
        private readonly ILayerAPISensorService _layerAPISensorService;


        public TestController(ILayerAPISensorService layerAPISensorService)
        {
            _layerAPISensorService = layerAPISensorService;
        }


        [HttpGet]
        public async Task<IReadOnlyList<LayerSensor>> GetAllSensors() =>
            await _layerAPISensorService.GetSensors();
    }
}
