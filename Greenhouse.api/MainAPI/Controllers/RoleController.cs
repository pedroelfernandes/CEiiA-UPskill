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
        public async Task<List<RoleDTO>> Get() =>
            await _roleService.Get();


        [HttpGet]
        public async Task<RoleDTO> GetRoleById(int id) =>
            await _roleService.GetRole(id);


        // Create a new role
        [HttpPost]
        public async Task<RoleDTO> Create(Role role) =>
            await _roleService.Create(role);


        // Edit role information
        [HttpPut]
        public async Task<RoleDTO> Edit(Role role) =>
            await _roleService.Edit(role);


        // Change state from active to inactive
        [HttpPut]
        public async Task<bool> ChangeState(int id) =>
           await _roleService.ChangeState(id);
    }
}
