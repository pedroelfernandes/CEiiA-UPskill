using Greenhouse.web.Models;
using Greenhouse.web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.web.Controllers
{
  
    [Route("[controller]/[action]")]
    public class APIUserController : Controller
    {
        private readonly IAPIUserServices _apiUserServices;

        public APIUserController (IAPIUserServices apiUserServices)
        {
            _apiUserServices = apiUserServices;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return View(new List<APIUser> { await _apiUserServices.Get(id) });
        }
        
        public IActionResult Get()
        {
            //var users = _apiUserServices.Get.Result;
            return View();
        }
    }
}
