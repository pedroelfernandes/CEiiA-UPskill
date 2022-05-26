
using Greenhouse.web.Models;
using Greenhouse.web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Greenhouse.web.Controllers
{
    public class APIsController : Controller
    {
       
        IConfiguration _configuration;
        public APIsController(IConfiguration configuration)
        {
          _configuration = configuration;
        }

        //DISPLAY API
        public IActionResult Index()
        {
            var aPIs = APIServices.GetAPI(_configuration).Result;

            return View(aPIs);
        }

        //TEST_SIMILAR TO MAIN
        [HttpGet]
        public async Task<List<API>> GetAPIs() =>
            (List<API>)await APIServices.GetAPI(_configuration);

        ////DISPLAY API
        //public IActionResult Index()
        //{
        //    string uri = _configuration.GetValue<string>("URI");
        //    var aPIs = API.GetAPIs(uri).Result;
        //    string uri = _configuration.GetValue<string>(ClientServices.GetAPI());


        //    return View(aPIs);
        //}

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


          
            return RedirectToAction("Index");
        }

        //method EDIT (by id)
        public IActionResult Edit(int? id)
        {

            API aPI = new();

            if (id is null)
                return BadRequest();

            if (id <= 0)
                return NotFound();

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

            //Return redirect to action
            return RedirectToAction("Index");
        }

        //DELETE
        public IActionResult Delete(int? id)
        {
            
            
           API aPI = new();

            if (id is null)
                return BadRequest();

            if (id <= 0)
                return NotFound();

            if (aPI == null)
                return NotFound();

            return View(aPI);
        }

        //HTTP Method: Post (handle the new input)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            API aPI = new();

            if (aPI == null)
                return NotFound();

            return RedirectToAction("Index");


        }
    }
}
