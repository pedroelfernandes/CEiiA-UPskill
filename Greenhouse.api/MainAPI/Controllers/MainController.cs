using MainAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : Controller
    {
        private readonly IConfiguration _configuration;



        public MainController(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        [HttpGet]
        public async Task<List<Reading>> GetLastByAPI(Uri uri) =>
            (List<Reading>)await MainAPI.Services.Services.GetLastByAPI(uri);



        [HttpGet]
        [Route("GetLastByAPIBySensorId")]
        public async Task<Reading> GetLastByAPIBySensorId(Uri uri, int id) =>
            (Reading) await MainAPI.Services.Services.GetLastByAPIBySensorId(uri, id);
    }
}
