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
        private readonly ISensorService _sensorService;


        public TestController(ILayerAPISensorService layerAPISensorService, IReadingService readingService, ISensorService sensorService)
        {
            _layerAPISensorService = layerAPISensorService;
            _readingService = readingService;
            _sensorService = sensorService;
        }


        [HttpGet]
        public async Task<IReadOnlyList<Sensor>> GetAllSensors() =>
            await _layerAPISensorService.GetSensors();


        [HttpGet]
        public async Task<List<Sensor>> GetAPISensors()
        {
            StoredURL storedURL = new StoredURL
            {
                Id = 1,
                Url = "https://localhost:44361/api/"
            };

            return await _layerAPISensorService.GetAPISensors(storedURL);
        }


        [HttpGet]
        public async Task<IReadOnlyList<Reading>> GetReadingsBySensorId(int urlId, string sensorId, int size) =>
            await _readingService.GetBySensorId(urlId, sensorId, size);


        [HttpGet]
        public async Task<IReadOnlyList<Reading>> GetReadingsBetweenDatesBySensorId(int urlId, string sensorId, DateTime startDate, DateTime endDate) =>
            await _readingService.GetBetweenDatesBySensorId(urlId, sensorId, startDate, endDate);


        [HttpGet]
        public async Task<bool> CheckForSensors() =>
            await _sensorService.CheckForNewSensors();
    }
}
