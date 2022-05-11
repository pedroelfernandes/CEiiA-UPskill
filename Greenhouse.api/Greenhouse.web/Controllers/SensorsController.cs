using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.web.Controllers
{
    public class SensorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
