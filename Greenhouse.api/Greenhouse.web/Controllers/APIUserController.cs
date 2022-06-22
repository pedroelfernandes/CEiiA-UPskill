using Greenhouse.web.Models;
using Greenhouse.web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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


        //Get all users
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<APIUser> users = await _apiUserServices.Get();

            return View(users);
        }


        //Get APIUser by Id

        [HttpGet("id")]
        public async Task<IActionResult> GetAPIUserById(int id)
        {
            var apiUser = await _apiUserServices.GetAPIUserById(id);
            return apiUser == null ? NotFound() : View(apiUser);
        }


        // create new role
        public async Task<IActionResult> Create()
        {
            List<Role> roles = await _rolesServices.Get();
            ViewBag.RoleId = new SelectList(roles, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(APIUser apiUser)
        {
            APIUser apiUserResult;

            if (ModelState.IsValid)
            {
                apiUserResult = await _apiUserServices.Create(apiUser);

                if (apiUserResult != null)
                {
                    return RedirectToAction("Get", apiUser);
                }
            }
            return View(apiUser);
        }


        //Edit APIUser
        public async Task<IActionResult> Edit(int id)
        {
            var apiUser = await _apiUserServices.GetAPIUserById(id);
            List<Role> roles = await _rolesServices.Get();
            ViewBag.RoleId = new SelectList(roles, "Id", "Name");
            return View(apiUser);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, APIUser apiUser)
        {
            if (id != apiUser.Id)
            {
                return BadRequest();
            }

            APIUser apiUserResult;
            if (ModelState.IsValid)
            {
                apiUserResult = await _apiUserServices.Edit(apiUser);

                if (apiUserResult != null)
                {
                    return RedirectToAction("Get");
                }
            }
            return View(await _apiUserServices.Get());
        }

        //Change state from true to false and vice versa for apiUsers
        [HttpGet]
        public async Task<IActionResult> ChangeState(int id)
        {
            bool res = await _apiUserServices.ChangeState(id);

            if (!res)
                ModelState.AddModelError("Error001", "Error while deleting the record");

            return RedirectToAction("Get");
        }
    }
}
