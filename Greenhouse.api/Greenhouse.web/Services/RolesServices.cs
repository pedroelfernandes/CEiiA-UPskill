using Greenhouse.web.Models;

namespace Greenhouse.web.Services
{
    public class RolesServices
    {
        // Ainda falta o model de "role" no client para dar "using"
        public async Task<List<Role>> Get(string roleId, IConfiguration configuration)
        {
            List<Role> roles = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"get?id={roleId}");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadFromJsonAsync<List<Role>>();

                if (res != null)
                {
                    roles = res;
                }
            }
            return roles;
        }

        public async Task<List<Role>> Create(string roleId, IConfiguration configuration)
        {
             List<Role> roles = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"get?id={roleId}");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadFromJsonAsync<List<Role>>();

                if (res != null)
                {
                    roles = res;
                }
            }
            return roles;
        }

        public async Task<List<Role>> Edit(string roleId, IConfiguration configuration)
        {
            List<Role> roles = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"get?id={roleId}");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadFromJsonAsync<List<Role>>();

                if (res != null)
                {
                    roles = res;
                }
            }
            return roles;
        }


        public async Task<List<Role>> ChangeState(string roleId, IConfiguration configuration)
        {
            List<Role> roles = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"get?id={roleId}");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadFromJsonAsync<List<Role>>();

                if (res != null)
                {
                    roles = res;
                }
            }
            return roles;
        }
    }
}
