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


        // create new role

        public IActionResult Create()
        {
            return View();
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

        //Get Role by Id

        [HttpGet("id")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var role = await _rolesServices.GetRoleById(id);
            return role == null ? NotFound() : View(role);
        }


        //Edit Role
        public async Task<IActionResult> Edit(int id)
        {
            var role = await _rolesServices.GetRoleById(id);
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Role role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }

            Role roleResult;
            if (ModelState.IsValid)
            {
                roleResult = await _rolesServices.Edit(role);

                if (roleResult != null)
                {
                    return RedirectToAction("Get");
                }
            }
            return View(await _rolesServices.Get());
        }

    }
}

