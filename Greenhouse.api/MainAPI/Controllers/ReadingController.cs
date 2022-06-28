using MainAPI.DTO;
using MainAPI.Models;
using MainAPI.Repositories.Interfaces;
using MainAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MainAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ReadingController : Controller
    {
        private readonly IReadingService _readingService;

        private readonly ISensorRepository _sensorRepository;

        private readonly IAssetService _assetService;


        public ReadingController(IReadingService readingService, ISensorRepository sensorRepository, IAssetService assetService)
        {
            _readingService = readingService;

            _sensorRepository = sensorRepository;

            _assetService = assetService;
        }


        [HttpGet]
        public async Task<List<Reading>> GetLastSensorReadings(int sensorId, int size = 10)
        {
            Sensor sensor = await _sensorRepository.GetSensor(sensorId);

            return await _readingService.GetBySensorId((int)sensor.URLId, sensor.IdInAPI, size);
        }


        [HttpGet]
        public async Task<List<List<Reading>>> GetLastAssetReadings(int assetId, int size = 10)
        {
            List<List<Reading>> readings = new();

            AssetDTO asset = await _assetService.GetAssetById(assetId);

            foreach (SensorDTO sensor in asset.Sensors)
                readings.Add(await GetLastSensorReadings(sensor.Id, size));

            return readings;
        }


        [HttpGet]
        public async Task<List<Reading>> GetBetweenDatesBySensorId(int sensorId, DateTime startDate, DateTime endDate)
        {
            Sensor sensor = await _sensorRepository.GetSensor(sensorId);

            return await _readingService.GetBetweenDatesBySensorId((int)sensor.URLId, sensor.IdInAPI, startDate, endDate);
        }


        [HttpGet]
        public async Task<List<List<Reading>>> GetBetweenDatesByAssetId(int assetId, DateTime? startDate, DateTime? endDate)
        {
            List<List<Reading>> readings = new();

            AssetDTO asset = await _assetService.GetAssetById(assetId);

            if (endDate == null)
                endDate = DateTime.UtcNow;

            if (startDate == null)
                startDate = new DateTime(endDate.Value.Date.Day - 1);
            
            foreach (SensorDTO sensor in asset.Sensors)
                readings.Add(await GetBetweenDatesBySensorId(sensor.Id, (DateTime)startDate, (DateTime)endDate));

            return readings;
        }
    }
}
