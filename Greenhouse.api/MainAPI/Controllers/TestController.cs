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
        private readonly IReadingService _readingService;


        public TestController(ILayerAPISensorService layerAPISensorService, IReadingService readingService)
        {
            _layerAPISensorService = layerAPISensorService;
            _readingService = readingService;
        }


        [HttpGet]
        public async Task<IReadOnlyList<LayerSensor>> GetAllSensors() =>
            await _layerAPISensorService.GetSensors();


        [HttpGet]
        public async Task<IReadOnlyList<Reading>> GetReadingsBySensorId(string urlId, string sensorId, int size) =>
            await _readingService.GetBySensorId(urlId, sensorId, size);


        [HttpGet]
        public async Task<IReadOnlyList<Reading>> GetReadingsBetweenDatesBySensorId(string urlId, string sensorId, DateTime startDate, DateTime endDate) =>
            await _readingService.GetBetweenDatesBySensorId(urlId, sensorId, startDate, endDate);
    }
}
