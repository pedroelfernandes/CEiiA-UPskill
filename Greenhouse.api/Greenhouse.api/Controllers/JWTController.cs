using Greenhouse.api.JwtHelper;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class JWTController : Controller
    {
        private readonly IJwtToken _jwtToken;


        public JWTController(IJwtToken jwtToken)
        {
            _jwtToken = jwtToken;
        }


        [HttpGet]
        public IActionResult GetToken() =>
            new ObjectResult(_jwtToken.GenerateJwtToken());
    }
}
