using Greenhouse.web.Models;
using Greenhouse.web.Services.Interfaces;

namespace Greenhouse.web.Services.Implementations
{
    public class AssetServices: IAssetServices
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
                var res = await response.Content.ReadFromJsonAsync<List<Asset>>();

                if (res != null)
                {
                    assets = res;
                }
            }
            return assets;
        }

        //    public static async Task<List<Asset>> Create(string assetId, IConfiguration configuration)
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
