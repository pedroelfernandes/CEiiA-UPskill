using Greenhouse.api.DTOs;
using Greenhouse.api.Enumerables;
using Greenhouse.api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.api.Controllers
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
        public async Task<IReadOnlyList<ReadingDTO>> GetBetweenDatesBySensorId(string sensorId, DateTime startDate, DateTime endDate, SortEnum sort = SortEnum.Descending, OrderEnum order = OrderEnum.ReadDate) =>
            await _readingService.GetBetweenDatesBySensorId(sensorId, startDate, endDate, sort, order);
    }
}
