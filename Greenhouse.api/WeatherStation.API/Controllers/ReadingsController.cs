using Microsoft.AspNetCore.Mvc;
using WeatherStation.api.DTOs;
using WeatherStation.api.Services.Interfaces;

namespace WeatherStation.api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ReadingsController : Controller
    {
        private readonly IReadingService _readingService;


        public ReadingsController(IReadingService readingService)
        {
            _readingService = readingService;
        }


        public async Task<IReadOnlyList<ReadingDTO>> GetBySensorId(string sensorId, int size, string sort = "desc", string order = "date") =>
            await _readingService.GetBySensorId(sensorId, size, sort, order);


        public async Task<IReadOnlyList<ReadingDTO>> GetBetweenDatesBySensorIdAsync(string sensorId, DateTime startDate, DateTime endDate, string sort = "desc", string order = "date") =>
            await _readingService.GetBetweenDatesBySensorId(sensorId, startDate, endDate, sort, order);
    }
}
