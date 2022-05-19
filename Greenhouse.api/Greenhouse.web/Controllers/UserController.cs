using Greenhouse.web.Data;
using Greenhouse.web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.web.Controllers
{
    public class UserController : Controller
    {

        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<User> users = _db.Users.ToList();
            return View(users);
        }

        public IActionResult Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            _db.Users.Add(user);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Login(User user)
        {
            if (user != null)
            {
                return View(user);
            }
            //_db.Users.FindAsync(user.UserName).;
            return View();
        }
    }
}
