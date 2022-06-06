namespace Greenhouse.web.Services
{
    public class AssetServices
    {
        public static async Task<List<Asset>> Get(string assetId, IConfiguration configuration)
        {
            List<Asset> assets = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"getapisensors?id={assetId}");

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

        public static async Task<List<Asset>> Create(string assetId, IConfiguration configuration)
        {
            List<Asset> assets = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"getapisensors?id={assetId}");

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


        public static async Task<List<Asset>> Edit(string assetId, IConfiguration configuration)
        {
            List<Asset> assets = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"getapisensors?id={assetId}");

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


        public static async Task<List<Asset>> ChangeState(string assetId, IConfiguration configuration)
        {
            List<Asset> assets = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"getapisensors?id={assetId}");

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
    }
}
