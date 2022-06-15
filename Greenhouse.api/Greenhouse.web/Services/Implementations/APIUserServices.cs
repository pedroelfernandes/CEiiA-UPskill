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


        // Create a new user
        public async Task<APIUser> Create(APIUser apiUser)
        {
            string url = _configuration.GetValue<string>("URL");

            HttpClient client = Helpers.Helpers.GetHttpClient(url);

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(apiUser), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(url + $"apiuser/create", httpContent);

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


        //public async Task<List<APIUser>> Edit()
        //{
        //    List<APIUser> apiUsers = new();

        //    HttpClient client = Helpers.Helpers.GetHttpClient(_configuration.GetValue<string>("URL"));

        //    HttpResponseMessage response = await client.GetAsync($"edit");

        //    response.EnsureSuccessStatusCode();

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var res = await response.Content.ReadFromJsonAsync<List<APIUser>>();

        //        if (res != null)
        //        {
        //            apiUsers = res;
        //        }
        //    }
        //    return apiUsers;
        //}


        //public async Task<List<APIUser>> ChangeState()
        //{
        //    List<APIUser> apiUsers = new();

        //    HttpClient client = Helpers.Helpers.GetHttpClient(_configuration.GetValue<string>("URL"));

        //    HttpResponseMessage response = await client.GetAsync($"changestate");

        //    response.EnsureSuccessStatusCode();

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var res = await response.Content.ReadFromJsonAsync<List<APIUser>>();

        //        if (res != null)
        //        {
        //            apiUsers = res;
        //        }
        //    }
        //    return apiUsers;
        //}
    }
}
