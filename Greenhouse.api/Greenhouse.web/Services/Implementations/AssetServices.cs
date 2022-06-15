using Greenhouse.web.Models;
using Greenhouse.web.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Greenhouse.web.Services.Implementations
{
    public class AssetServices : IAssetServices
    {
        private readonly IConfiguration _configuration;

        public AssetServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Asset>> GetAssets()
        {
            List<Asset> assets = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(_configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync("Asset/GetAssets");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                List<Asset> res = await response.Content.ReadFromJsonAsync<List<Asset>>();

                if (res != null)
                {
                    assets = res;
                }
            }
            return assets;
        }

        ////Create new Asset
        //public async Task<Asset> CreateAsset(Asset asset)
        //{
        //    string url = _configuration.GetValue<string>("URL");

        //    HttpClient client = Helpers.Helpers.GetHttpClient(url);

        //    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(asset), Encoding.UTF8);
        //    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //    var response = await client.PostAsync(url + $"Asset/CreateAsset", httpContent);

        //    response.EnsureSuccessStatusCode();

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var res = JsonConvert.DeserializeObject<Asset>(await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync());

        //        if (res != null)
        //        {
        //            return res;
        //        }
        //    }
        //    return new Asset();
        //}




        //    public static async Task<List<Asset>> Edit(string assetId, IConfiguration configuration)
        //    {
        //        List<Asset> assets = new();

        //        HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

        //        HttpResponseMessage response = await client.GetAsync($"getapisensors?id={assetId}");

        //        response.EnsureSuccessStatusCode();

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var res = await response.Content.ReadFromJsonAsync<List<Asset>>();

        //            if (res != null)
        //            {
        //                assets = res;
        //            }
        //        }
        //        return assets;
        //    }


        //    public static async Task<List<Asset>> ChangeState(string assetId, IConfiguration configuration)
        //    {
        //        List<Asset> assets = new();

        //        HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

        //        HttpResponseMessage response = await client.GetAsync($"getapisensors?id={assetId}");

        //        response.EnsureSuccessStatusCode();

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var res = await response.Content.ReadFromJsonAsync<List<Asset>>();

        //            if (res != null)
        //            {
        //                assets = res;
        //            }
        //        }
        //        return assets;
        //    }
        //}
    }
}
