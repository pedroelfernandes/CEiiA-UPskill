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


        //Get list of AssetTypes
        public async Task<List<Asset>> GetAssets()
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


        //Get Asset by Id
        public async Task<Asset> GetAssetById(int id)
        {
            Asset asset = new();
            string url = _configuration.GetValue<string>("URL");
            HttpClient client = Helpers.Helpers.GetHttpClient(url);
            HttpResponseMessage response = await client.GetAsync($"Asset/GetAsset?id={id}");
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                asset = await response.Content.ReadFromJsonAsync<Asset>();

                if (asset == null)
                {
                    throw new Exception("Asset not found.");
                }
            }
            return asset;
        }


        //Create new Asset
        public async Task<Asset> CreateAsset(Asset asset)
        {
            string url = _configuration.GetValue<string>("URL");
            HttpClient client = Helpers.Helpers.GetHttpClient(url);
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(asset), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.PostAsync(url + $"Asset/CreateAsset", httpContent);
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                Asset res = JsonConvert.DeserializeObject<Asset>(await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync());

                if (res != null)
                    asset = res;
            }

            return asset;
        }

        
        //Edit a specific Asset
        public async Task<Asset> EditAsset(Asset asset)
        {
            string url = _configuration.GetValue<string>("URL");
            HttpClient client = Helpers.Helpers.GetHttpClient(url);
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(asset), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PutAsync(url + $"Asset/EditAsset", httpContent);
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = JsonConvert.DeserializeObject<Asset>(await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync());

                if (res != null)
                    asset = res;
            }

            return asset;
        }


        //Delete-change status asset(bool)
        public async Task<bool> ChangeStateAsset(int id)
        {
            Asset asset = new();
            string url = _configuration.GetValue<string>("URL");
            HttpClient client = Helpers.Helpers.GetHttpClient(url);
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(asset), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PutAsync(url + $"Asset/ChangeState?id={id}", httpContent);
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<bool>(await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync());
            }
            return false;
        }
    }
}
