using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using WeatherStation.api.DTOs;
using WeatherStation.api.Models;
using WeatherStation.api.Services;
using WeatherStation.api.Services.Interfaces;

namespace WeatherStation.api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class Readingsv2Controller : Controller
    {
        private readonly IReadingService _readingService;

        public Readingsv2Controller(IReadingService readingService)
        {
            _readingService = readingService;
        }


        [HttpGet]
        public async Task<IReadOnlyList<ReadingDTO>> GetAllBySensorId(string id, string sort, int size, string order)
            => await _readingService.GetAllReadingsBySensorIdAsync(id, sort, size, order);

        [HttpPost]
        public async Task<IReadOnlyList<SensorDTO>> GetSesorDetailsByIdList(List<string> id, string sort, string order) =>
            await _readingService.GetSensorDetailsByIdListAsync(id, sort, order);


        [HttpGet]
        public async Task<ReadingDTO> GetReadingById(string id) =>
            await _readingService.GetReadingByIdAsync(id);


        [HttpGet]
        public async Task<DeleteResult> DeleteReading(string id) =>
          await _readingService.DeleteReadingByIdAsync(id);
    }
}
