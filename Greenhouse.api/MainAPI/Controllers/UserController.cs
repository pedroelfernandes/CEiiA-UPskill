using MainAPI.Data;
using MainAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MainAPI.Services;

namespace MainAPI.Controllers
{
    public class UserController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;

        public UserController(IConfiguration configuration, ApplicationDbContext db)
        {
            _configuration = configuration;
            _db = db;
        }


        [HttpGet]
        public async Task<bool> AuthenticateUser(string username, string password)
            => await UserServices.AuthenticateUser(username, password, _db);
    }
}
