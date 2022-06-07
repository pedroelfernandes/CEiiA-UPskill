using Greenhouse.web.Models;

namespace Greenhouse.web.Services.Implementations
{
    public class APIServices
    {
        public static async Task<IEnumerable<API>> GetAPI(IConfiguration configuration)
        {
            IEnumerable<API> apis = new List<API>();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync("getapis");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadFromJsonAsync<List<API>>();

                if (res != null)
                {
                    apis = res;
                }
            }
            return apis;
        }
    }
}
