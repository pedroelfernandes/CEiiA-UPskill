using Greenhouse.web.Models;
using MainAPI.HttpClientHelper;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.web.Controllers
{
    public class AssetTypesController : Controller
    {      

        private readonly IAssetTypeServices _assetTypeServices;
        public AssetTypesController(IAssetTypeServices assetTypeServices)
        {
            _assetTypeServices = assetTypeServices;
        }


        //Get Full List of AssetTypes

        [HttpGet]
        public async Task<IActionResult> GetAssetTypes() => await _assetTypeServices.GetAssetTypes(Enumerables.SortItem.ASC, Enumerables.OrderItem.Id);


        //


    }
}
