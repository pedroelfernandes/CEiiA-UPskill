using Greenhouse.web.Models;
using Greenhouse.web.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Greenhouse.web.Services.Implementations
{
    public class RolesServices : IRolesServices
    {
        private readonly IConfiguration _configuration;


        public RolesServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // Ainda falta o model de "role" no client para dar "using"
        public async Task<List<Role>> Get()
        {
            List<Role> roles = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(_configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"role/get");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                List<Role> res = await response.Content.ReadFromJsonAsync<List<Role>>();

                if (res != null)
                {
                    roles = res;
                }
            }
            return roles;
        }



        // Get role by id

        public async Task<Role> GetRoleById(int id)
        {
            Role role = new();
            string url = _configuration.GetValue<string>("URL");

            HttpClient client = Helpers.Helpers.GetHttpClient(url);

            HttpResponseMessage response = await client.GetAsync($"role/GetRoleById?id={id}");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                role = await response.Content.ReadFromJsonAsync<Role>();

                if (role == null)
                {
                    throw new Exception("Role not found.");
                }
            }
            return role;
        }



        // Create new role

        public async Task<Role> Create(Role role)
        {
            string url = _configuration.GetValue<string>("URL");

            HttpClient client = Helpers.Helpers.GetHttpClient(url);

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(role), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            var response = await client.PostAsync(url + $"role/create", httpContent);

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = JsonConvert.DeserializeObject<Role>(await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync());

                if (res != null)
                {
                    return res;
                }
            }
            return new Role();
        }
       
        
        
        //Edit a specific Role 
        public async Task<Role> Edit(Role role)
        {
            string url = _configuration.GetValue<string>("URL");

            HttpClient client = Helpers.Helpers.GetHttpClient(url);
            //string json = "{" + $"id={role.Id}; name={role.Name}; description={role.Description}; isActive={role.IsActive}" + "}";
            //string json2 = JsonConvert.SerializeObject(role);
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(role), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            var response = await client.PutAsync(url + $"role/edit", httpContent);

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = JsonConvert.DeserializeObject<Role>(await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync());

                if (res != null)
                {
                    return res;
                }
            }
            return new Role();

        }

        // Change state from true to false and vice versa for roles
        public async Task<bool> ChangeState(int id)
        {
            Role role = new();

            string url = _configuration.GetValue<string>("URL");

            HttpClient client = Helpers.Helpers.GetHttpClient(url);
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(role), Encoding.UTF8);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync(url + $"role/ChangeState?id={id}", httpContent);

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<bool>(await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync());
            }
            return false;
        }
    }
}
