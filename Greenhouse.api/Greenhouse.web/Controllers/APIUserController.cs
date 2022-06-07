using Greenhouse.web.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.web.Controllers
{
    [Route("api/[action]")]
    public class APIUserController : Controller
    {
        private readonly IConfiguration _configuration;

        public APIUserController (IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public async Task<ActionResult> Get(string apiUserId)
        {
            return View(await APIUserServices.Get(apiUserId, _configuration));
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
