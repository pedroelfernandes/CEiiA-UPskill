namespace Greenhouse.web.Services
{
    public class AssetTypeServices
    {
        public static async Task<List<AssetType>> Get(string assetTypeId, IConfiguration configuration)
        {
            List<AssetType> assetTypes = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"getapisensors?id={assetTypeId}");

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

        public static async Task<List<AssetType>> Create(string assetTypeId, IConfiguration configuration)
        {
            List<AssetType> assetTypes = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"getapisensors?id={assetTypeId}");

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


        public static async Task<List<AssetType>> Edit(string assetTypeId, IConfiguration configuration)
        {
            List<AssetType> assetTypes = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"getapisensors?id={assetTypeId}");

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


        public static async Task<List<AssetType>> ChangeState(string assetTypeId, IConfiguration configuration)
        {
            List<AssetType> assetTypes = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"getapisensors?id={assetTypeId}");

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
    }
}
