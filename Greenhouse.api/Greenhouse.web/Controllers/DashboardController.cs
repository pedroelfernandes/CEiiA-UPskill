using Greenhouse.web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IAssetServices _assetServices;


        public DashboardController(IAssetServices assetServices)
        {
            _assetServices = assetServices;
        }


        public async Task<IActionResult> Index() =>
            View(await _assetServices.GetAssets());
    }
}
