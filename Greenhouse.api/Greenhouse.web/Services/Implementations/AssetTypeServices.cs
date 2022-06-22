using Greenhouse.web.Models;
using Greenhouse.web.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Greenhouse.web.Services.Implementations
{
    public class AssetTypeServices: IAssetTypeServices
    {
        private readonly IConfiguration _configuration;
        public AssetTypeServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        //Get list of AssetTypes
        public async Task<List<AssetType>> GetAssetTypes()
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



        //Create new AssetType
        public async Task<AssetType> CreateAssetType(AssetType assetType)
        {
            string url = _configuration.GetValue<string>("URL");

            HttpClient client = Helpers.Helpers.GetHttpClient(url);

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(assetType), Encoding.UTF8);
            
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            var response = await client.PostAsync(url + $"AssetType/CreateAssetType", httpContent);
            
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = JsonConvert.DeserializeObject<AssetType>(await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync());

                if (res != null)
                {
                    return res;
                }
            }
            return new AssetType();
        }



        //Get Asset Type by Id
        public async Task<AssetType> GetAssetTypeById(int id)
        {
            AssetType assetType = new();
            string url = _configuration.GetValue<string>("URL");
            HttpClient client = Helpers.Helpers.GetHttpClient(url);
            HttpResponseMessage response = await client.GetAsync($"AssetType/GetAssetTypeById?id={id}");
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                assetType = await response.Content.ReadFromJsonAsync<AssetType>();

                if (assetType == null)
                {
                    throw new Exception("AssetType not found.");
                } 
            }
            return assetType;
        }



        //Edit a specific Asset Type
        public async Task<AssetType> EditAssetType(AssetType assetType)
        {
            string url = _configuration.GetValue<string>("URL");
            HttpClient client = Helpers.Helpers.GetHttpClient(url);
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(assetType), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PutAsync(url + $"AssetType/EditAssetType", httpContent);
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = JsonConvert.DeserializeObject<AssetType>(await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync());

                if (res != null)
                {
                    return res;
                }
            }
            return new AssetType();
        }



        //Delete-change status assetType(bool)
        public async Task<bool> ChangeStateAssetType(int id)
        {
            AssetType assetType = new();
            string url = _configuration.GetValue<string>("URL");
            HttpClient client = Helpers.Helpers.GetHttpClient(url);
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(assetType), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PutAsync(url + $"AssetType/ChangeStateAssetType?id={id}", httpContent);
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                 return JsonConvert.DeserializeObject<bool>(await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync());
            }
            return false;
        }
    }
}
