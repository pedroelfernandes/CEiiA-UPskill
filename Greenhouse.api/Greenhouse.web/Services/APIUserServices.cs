using Greenhouse.web.Models;

namespace Greenhouse.web.Services
{
    public class APIUserServices
    {
        public static async Task<List<APIUser>> Get(string apiUserId, IConfiguration configuration)
        {
            List<APIUser> apiUsers = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"getapisensors?id={apiUserId}");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadFromJsonAsync<List<APIUser>>();

                if (res != null)
                {
                    apiUsers = res;
                }
            }
            return apiUsers;
        }

        public static async Task<List<APIUser>> Create(string apiUserId, IConfiguration configuration)
        {
            List<APIUser> apiUsers = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"getapisensors?id={apiUserId}");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadFromJsonAsync<List<APIUser>>();

                if (res != null)
                {
                    apiUsers = res;
                }
            }
            return apiUsers;
        }


        public static async Task<List<APIUser>> Edit(string apiUserId, IConfiguration configuration)
        {
            List<APIUser> apiUsers = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"getapisensors?id={apiUserId}");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadFromJsonAsync<List<APIUser>>();

                if (res != null)
                {
                    apiUsers = res;
                }
            }
            return apiUsers;
        }


        public static async Task<List<APIUser>> ChangeState(string apiUserId, IConfiguration configuration)
        {
            List<APIUser> apiUsers = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"getapisensors?id={apiUserId}");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadFromJsonAsync<List<APIUser>>();

                if (res != null)
                {
                    apiUsers = res;
                }
            }
            return apiUsers;
        }
    }
}
