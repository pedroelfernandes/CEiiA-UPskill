using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;

namespace Greenhouse.web.Models
{
    public class API
    {
        [Required]
        public int Id { get; set; }


        [Required, StringLength(50)]
        public string Name { get; set; } = null!;


        [StringLength(250)]
        public string Description { get; set; } = null!;

        //public static async Task<IEnumerable<API>> GetAPIs(string uri)
        //{
        //    IEnumerable<API> apis = new List<API>();

        //    HttpClient client = Helpers.Helpers.GetHttpClient(uri);

        //    HttpResponseMessage response = await client.GetAsync("Main/GetAPIs");

        //    response.EnsureSuccessStatusCode();

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var res = await response.Content.ReadFromJsonAsync<List<API>>();

        //        if (res != null)
        //        {
        //            apis = res;
        //        }
        //    }


        //    return apis;

        
        //    public static async Task<API> CreateAPI(string uri, API api)
        //{


        //    HttpClient client = Helpers.Helpers.GetHttpClient(uri);

        //    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(api), Encoding.UTF8);
        //    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //    var response = await client.PostAsync(uri + "Main/GetAPIs", httpContent);

        //    response.EnsureSuccessStatusCode();

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var res = JsonConvert.DeserializeObject<API>(await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync());


        //        if (res != null)
        //        {
        //            api = res;
        //        }
        //    }

        //    return api;
        //}

    }
}

