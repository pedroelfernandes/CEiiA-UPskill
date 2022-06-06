using MainAPI.DTO;
using MainAPI.Models;
using MainAPI.Services.Implementations;
using MainAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MainAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<RoleDTO> Get(int id) => await _roleService.Get(id);


        // Create a new role
        [HttpPost]
        public async Task<RoleDTO> Create (string name, bool active)
        {
            Role? role = new()
            {
                Name = name,
                Active = active
            };

            return await _roleService.Create(role);
        }


        // Edit role information
        [HttpPut]
        public async Task<RoleDTO> Edit(int id, string name, string description)
        {
            return await _roleService.Edit(id, name, description);
        }


        // Change state from active to inactive
        [HttpPut]
        public async Task<bool> ChangeState(int id)
        {
           return await _roleService.ChangeState(id);
        }
    }
}
