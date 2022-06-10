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

        //Get list of AssetTypes
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


        //public static async Task<List<AssetType>> Create(string Id, IConfiguration configuration)
        //{
        //    List<AssetType> assetTypes = new();

        //    HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

        //    HttpResponseMessage response = await client.GetAsync($"AssetType/Create?id={Id}");

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

        //public async Task<AssetType> CreateAssetType(AssetType assetType, IConfiguration configuration)
        //{
        //    if (assetType == null)
        //        throw new Exception("AssetType not defined.");

        //    await _configuration.AssetTypes.AddAsync(assetType);
        //    await _configuration.SaveChangesAsync();
        //    return assetType;
        //}




        ////Get Asset Type by Id
        //public static async Task<AssetType> GetAssetTypeById(int Id, IConfiguration configuration)
        //{

        //    HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

        //    HttpResponseMessage response = await client.GetAsync($"AssetType/GetAssetTypeById?id={Id}");

        //    response.EnsureSuccessStatusCode();

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var res = await response.Content.ReadFromJsonAsync<AssetType>();

        //        if (res == null)
        //        {
        //            throw new Exception("AssetType not found.");
        //        }
        //    }
        //    return assetType;
        //}

        //public async Task<AssetType> GetAssetTypeById(int Id)
        //{
        //    HttpClient client = Helpers.Helpers.GetHttpClient(_configuration.GetValue<string>("URL"));
        //    AssetType assetType = await _configuration.GetAsync($"getAssetType?id={Id}");

        //    if (assetType == null)
        //        throw new Exception("AssetType not found.");

        //    return assetType;
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
