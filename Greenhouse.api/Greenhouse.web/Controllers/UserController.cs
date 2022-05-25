using Greenhouse.web.Data;
using Greenhouse.web.Models;
using Greenhouse.web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.web.Controllers
{
    public class UserController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;

        public UserController(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            List<User> users = _db.Users.ToList();
            return View(users);
        }

        public async Task<IActionResult> Create(User user)
        {
            //form must be valid
            if (!ModelState.IsValid)
            {
                return View(user);
            }
 
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Login()
        {
            //if (user != null)
            //{
            //    return View(user);
            //}
            //_db.Users.FindAsync(user.UserName).;
            return RedirectToAction("UserDashboard");

            //if (ModelState.IsValid)
            //{
            //    if (ValidateUser(user.EmailAddress, user.Password))
            //    {

            //        FormsAuthentication.SetAuthCookie(user.EmailAddress, false);
            //        return RedirectToAction("Index", "Members");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "");
            //    }
            //}
            //return View();

        }


        ////[HttpPost]
        ////[Authorize]
        //public async Task<IActionResult> Logout(User user)
        //{
        //    //FormsAuthentication.SignOut();
        //    if (user != null)
        //    {
        //        return View(user);
        //    }
        //    return RedirectToAction("Login");
        //}


        //public async Task<IActionResult> UserDashboard()
        //{
        //    return View(await ReadingServices.GetAPI(_configuration));
        //}


        public async Task<IActionResult> UserDashboard1(string apiId, string sensorId)
        {
            return View(await ReadingServices.GetLastSensorValue(apiId, sensorId, _configuration));
        }

        public async Task<IActionResult> EditUserSettings(int? userId)
        {
            //variables
            User? user;

            //value cannot be null
            if (userId == null)
                return BadRequest();

            // value must be greater than zero
            if (userId <= 0)
                return NotFound();

            //get the user
            user = _db.Users.Find(userId);

            //user must exist
            if (user is null)
                return NotFound();


            //_db.Users.FindAsync(user.UserName).;

            //show the form with the user settings
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserSettings(User user)
        {
            //form must be valid
            if (!ModelState.IsValid)
                return View(user);

            // update new input data
            _db.Users.Update(user);
            _db.SaveChanges();
            return RedirectToAction("UserDashboard");
        }
    }
}
