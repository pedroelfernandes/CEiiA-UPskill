using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherStation.api.DTOs;
using WeatherStation.api.Enumerables;
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


        [HttpGet]
        [Authorize]
        public async Task<IReadOnlyList<ReadingDTO>> GetBySensorId(string sensorId, int size, SortEnum sort = SortEnum.Descending, OrderEnum order = OrderEnum.ReadDate) =>
            await _readingService.GetBySensorId(sensorId, size, sort, order);


        [HttpGet]
        [Authorize]
        public async Task<IReadOnlyList<ReadingDTO>> GetBetweenDatesBySensorIdAsync(string sensorId, DateTime startDate, DateTime endDate, SortEnum sort, OrderEnum order = OrderEnum.ReadDate) =>
            await _readingService.GetBetweenDatesBySensorId(sensorId, startDate, endDate, sort, order);
    }
}
