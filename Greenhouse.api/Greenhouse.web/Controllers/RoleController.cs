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



        // get all roles
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Role> roles = await _rolesServices.Get();

            return View(roles);
        }


        [HttpPost]
        public async Task<IActionResult> Create (Role role)
        {
            Role roleResult;

            if (ModelState.IsValid)
            {
                roleResult = await _rolesServices.Create(role);

                if(roleResult != null)
                {
                    return RedirectToAction("Get", role);
                }
            }
            return View(role);
        }
    }
}
