using Greenhouse.web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.web.Controllers
{
    [Route("[controller]/[action]")]
    public class SensorTypesController : Controller
    {

        private readonly ISensorTypeServices _sensorTypeServices;
        public SensorTypesController(ISensorTypeServices sensorTypeServices)
        {
            _sensorTypeServices = sensorTypeServices;
        }

    }
}
