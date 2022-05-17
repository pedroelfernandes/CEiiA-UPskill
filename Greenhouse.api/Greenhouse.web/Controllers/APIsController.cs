using Greenhouse.web.Data;
using Greenhouse.web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.web.Controllers
{
    public class APIsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public APIsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<API> aPIs = _db.APIs.ToList();
            return View(aPIs);
        }

        //ADD function (CREATE)
        public IActionResult Create()
        {
            return View();
        }

        //ADD function (Post) (handle the new API)
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(API aPI)
        {
            _db.APIs.Add(aPI);
            _db.SaveChanges();
            //Return redirect to action

            return RedirectToAction("Index");
        }

        //method EDIT (by int)
        public IActionResult Edit(int? id)
        {
            API aPI;

            if (id is null)
                return BadRequest();

            if (id <= 0)
                return NotFound();

            aPI = _db.APIs.Find(id);

            if (aPI == null)
                return NotFound();

            return View(aPI);
        }

        //Method EDIT - Post (handle the new input)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(API aPI)
        {

            //validate the model rules
            if (!ModelState.IsValid)
                return View(aPI);

            _db.APIs.Update(aPI);
            _db.SaveChanges(); //save in the base
            //Return redirect to action

            return RedirectToAction("Index");
        }
    }
}
