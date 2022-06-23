using Greenhouse.web.Models;
using Greenhouse.web.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Greenhouse.web.Services.Implementations
{
    public class APIUserServices : IAPIUserServices
    {
        private readonly IConfiguration _configuration;

        public APIUserServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<APIUser>> Get()
        {
            List<APIUser> apiUsers = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(_configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"apiuser/get");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                List<APIUser> res = await response.Content.ReadFromJsonAsync<List<APIUser>>();

                if (res != null)
                {
                    apiUsers = res;
                }
            }
            return apiUsers;
        }


        // Get APIUser by id

        public async Task<APIUser> GetAPIUserById(int id)
        {
            APIUser apiUser = new();
            string url = _configuration.GetValue<string>("URL");

            HttpClient client = Helpers.Helpers.GetHttpClient(url);

            HttpResponseMessage response = await client.GetAsync($"apiuser/GetAPIUserById?id={id}");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                apiUser = await response.Content.ReadFromJsonAsync<APIUser>();

                if (apiUser == null)
                {
                    throw new Exception("APIUser not found.");
                }
            }
            return apiUser;
        }


        // Create a new user
        public async Task<APIUser> Create(APIUser apiUser)
        {
            string url = _configuration.GetValue<string>("URL");

            HttpClient client = Helpers.Helpers.GetHttpClient(url);

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(apiUser), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(url + $"apiuser/create?password={apiUser.Password}", httpContent);

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = JsonConvert.DeserializeObject<APIUser>(await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync());

                if (res != null)
                {
                    return res;
                }
            }
            return new APIUser();
        }


        //Edit a specific APIUser 
        public async Task<APIUser> Edit(APIUser apiUser)
        {
            string url = _configuration.GetValue<string>("URL");

            HttpClient client = Helpers.Helpers.GetHttpClient(url);
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(apiUser), Encoding.UTF8);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response;
            if (apiUser.Password != null && apiUser.OldPassword != null)
                response = await client.PutAsync(url + $"apiuser/create?newpassword={apiUser.Password}&oldpassword={apiUser.OldPassword}", httpContent);
            else
                response = await client.PutAsync(url + $"apiuser/create", httpContent);

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = JsonConvert.DeserializeObject<APIUser>(await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync());

                if (res != null)
                {
                    return res;
                }
            }
            return new APIUser();

        }


        // Change state from true to false and vice versa for api users
        public async Task<bool> ChangeState(int id)
        {
            APIUser apiUser = new();

            string url = _configuration.GetValue<string>("URL");

            HttpClient client = Helpers.Helpers.GetHttpClient(url);
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(apiUser), Encoding.UTF8);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync(url + $"apiuser/ChangeState?id={id}", httpContent);

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<bool>(await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync());
            }
            return false;
        }
    }
}
