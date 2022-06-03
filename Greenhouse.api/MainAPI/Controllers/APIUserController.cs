﻿using MainAPI.Data;
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


        [HttpGet]
        //public async Task<bool> AuthenticateAPIUser(string username, string password)
        //    => true;
        public async Task<APIUserDTO> Get(int id) =>
            await _apiUserService.Get(id);


        // Create a new user
        [HttpPost]
        public async Task<APIUserDTO> Create(string username,string password, string email, bool active, int roleId )
        {
            APIUser? apiUser = new()
            {
                Username = username,
                Password = password,
                Email = email,
                Active = active,
                RoleId = roleId
            };
            return await _apiUserService.Create(apiUser);
        }

        // Edit user information
        [HttpPut]
        public async Task<APIUserDTO> Edit(int id, string name, string email, int roleId)
        {
            return await _apiUserService.Edit(id, name, email, roleId);
        }


        // Change state from active to inactive
        [HttpPut]
        public async Task<bool> ChangeState(int id)
        {
            return await _apiUserService.ChangeState(id);
        }
    }
}
