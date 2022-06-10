using Greenhouse.web.Services.Interfaces;
using Greenhouse.web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.web.Controllers
{
    [Route("[controller]/[action]")]
    public class RoleController : Controller
    {
        private readonly IRolesServices _rolesServices;

        public RoleController(IRolesServices rolesServices)
        {
            _rolesServices = rolesServices;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Role> roles = await _rolesServices.Get();

            return View(roles);
        }

    }
}
