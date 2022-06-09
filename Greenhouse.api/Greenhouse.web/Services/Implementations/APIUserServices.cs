using Greenhouse.web.Models;
using Greenhouse.web.Services.Interfaces;

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

        //public async Task<List<APIUser>> Create()
        //{
        //    List<APIUser> apiUsers = new();

        //    HttpClient client = Helpers.Helpers.GetHttpClient(_configuration.GetValue<string>("URL"));

        //    HttpResponseMessage response = await client.GetAsync($"create");

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
