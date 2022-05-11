﻿using Greenhouse.api.Models;
using Greenhouse.api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ReadingsController : ControllerBase
    {
        private readonly GreenhouseService _greenhouseService;



        public ReadingsController(GreenhouseService greenhouseService)
        {
            _greenhouseService = greenhouseService;
        }



        [HttpGet]
        public async Task<List<Reading>> Get() => 
            await _greenhouseService.GetAsync();



        [HttpGet]
        [Route("GetLast")]
        public List<Reading> GetLast() =>
            _greenhouseService.GetLast();
    }
}
