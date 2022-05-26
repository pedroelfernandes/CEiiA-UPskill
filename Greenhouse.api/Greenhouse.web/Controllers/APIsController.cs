
using Greenhouse.web.Models;
using Greenhouse.web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Greenhouse.web.Controllers
{
    [Route("api/[action]")]
    public class APIsController : Controller
    {
       
        private readonly IConfiguration _configuration;
        public APIsController(IConfiguration configuration)
        {
          _configuration = configuration;
        }


        //GetAPIs

        public async Task<IActionResult> GetAPIs()
        {
            //ViewBag.apiId = apiId;
            return View(await APIServices.GetAPI(_configuration));

        }
    }
}
