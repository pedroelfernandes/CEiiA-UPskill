using Greenhouse.web.Data;
using Greenhouse.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Greenhouse.web.Controllers
{
    public class APIsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public APIsController(ApplicationDbContext db)
        {
            _db = db;
        }

        //DISPLAY API
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

        //ADD function (CREATE-POST to Index)
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(API aPI)
        {

            //validate the model rules
            if (!ModelState.IsValid)
                return View(aPI);

            _db.APIs.Add(aPI);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //method EDIT (by id)
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
        public IActionResult Edit(int apiId, API aPI)
        {

            //validate the model rules
            if (!ModelState.IsValid)
                return View(aPI);

            _db.Entry(aPI).State = EntityState.Modified;
            _db.SaveChanges();
            //Return redirect to action
            return RedirectToAction("Index");
        }

        //DELETE
        public IActionResult Delete(int? id)
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

        //HTTP Method: Post (handle the new input)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            API aPI;
            aPI = _db.APIs.Find(id);

            if (aPI == null)
                return NotFound();

            _db.APIs.Remove(aPI);
            //_db.Entry(aPI).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
