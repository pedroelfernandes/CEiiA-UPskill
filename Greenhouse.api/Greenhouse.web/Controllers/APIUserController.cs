using Greenhouse.web.Models;
using Greenhouse.web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.web.Controllers
{
  
    [Route("[controller]/[action]")]
    public class APIUserController : Controller
    {
        private readonly IAPIUserServices _apiUserServices;
        private readonly IRolesServices _rolesServices;

        public APIUserController (IAPIUserServices apiUserServices, IRolesServices rolesServices)
        {
            _apiUserServices = apiUserServices;
            _rolesServices = rolesServices;
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<APIUser> users = await _apiUserServices.Get();
            
            return View(users);
        }
        
        
    }
}
