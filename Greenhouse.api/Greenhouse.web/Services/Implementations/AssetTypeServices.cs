using Greenhouse.web.Models;
using Greenhouse.web.Services.Interfaces;

namespace Greenhouse.web.Services.Implementations
{
    public class AssetTypeServices: IAssetTypeServices
    {

        private readonly IConfiguration _configuration;

        public AssetTypeServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<IEnumerable<AssetType>> GetAssetTypes()
        {
            List<AssetType> assetTypes = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(_configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync("AssetType/GetAssetTypes");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadFromJsonAsync<List<AssetType>>();

                if (res != null)
                {
                    assetTypes = res;
                }
            }
            return assetTypes;
        }





        //public static async Task<List<AssetType>> Create(string assetTypeId, IConfiguration configuration)
        //{
        //    List<AssetType> assetTypes = new();

        //    HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

        //    HttpResponseMessage response = await client.GetAsync($"getapisensors?id={assetTypeId}");

        //    response.EnsureSuccessStatusCode();

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var res = await response.Content.ReadFromJsonAsync<List<AssetType>>();

        //        if (res != null)
        //        {
        //            assetTypes = res;
        //        }
        //    }
        //    return assetTypes;
        //}


        //public static async Task<List<AssetType>> Edit(string assetTypeId, IConfiguration configuration)
        //{
        //    List<AssetType> assetTypes = new();

        //    HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

        //    HttpResponseMessage response = await client.GetAsync($"getapisensors?id={assetTypeId}");

        //    response.EnsureSuccessStatusCode();

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var res = await response.Content.ReadFromJsonAsync<List<AssetType>>();

        //        if (res != null)
        //        {
        //            assetTypes = res;
        //        }
        //    }
        //    return assetTypes;
        //}


        //public static async Task<List<AssetType>> ChangeState(string assetTypeId, IConfiguration configuration)
        //{
        //    List<AssetType> assetTypes = new();

        //    HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

        //    HttpResponseMessage response = await client.GetAsync($"getapisensors?id={assetTypeId}");

        //    response.EnsureSuccessStatusCode();

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var res = await response.Content.ReadFromJsonAsync<List<AssetType>>();

        //        if (res != null)
        //        {
        //            assetTypes = res;
        //        }
        //    }
        //    return assetTypes;
        //}
    }
}
