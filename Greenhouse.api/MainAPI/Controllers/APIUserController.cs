using MainAPI.Data;
using MainAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MainAPI.Services;
using MainAPI.Services.Implementations;
using MainAPI.Services.Interfaces;
using MainAPI.DTO;

namespace MainAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class APIUserController : Controller
    {
        private readonly IAPIUserService _apiUserService;


        public APIUserController(IAPIUserService apiUserService)
        {
            _apiUserService = apiUserService;
        }


        // Create a new user
        [HttpPost]
        public async Task<APIUserDTO> Create(APIUserDTO apiUserDTO, string password) =>
            await _apiUserService.Create(apiUserDTO, password);


        [HttpGet]
        public async Task<List<APIUserDTO>> Get() =>
            await _apiUserService.Get();


        [HttpGet]
        public async Task<APIUserDTO> GetAPIUserById(int id) =>
            await _apiUserService.Get(id);


        // Change state from active to inactive
        [HttpPut]
        public async Task<bool> ChangeState(int id) =>
            await _apiUserService.ChangeState(id);


        // Edit user information
        [HttpPut]
        public async Task<APIUserDTO> Edit(APIUserDTO apiUserDTO, string? oldPassword, string? newPassword) =>
            await _apiUserService.Edit(apiUserDTO, oldPassword, newPassword);


        [HttpGet]
        public async Task<IActionResult> Login(string username, string password) =>
            new ObjectResult(await _apiUserService.Login(username, password));
    }
}
