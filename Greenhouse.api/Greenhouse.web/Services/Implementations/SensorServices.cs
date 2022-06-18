using Greenhouse.web.Models;
using Greenhouse.web.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Greenhouse.web.Services.Implementations
{
    public class SensorServices: ISensorServices
    {

        private readonly IConfiguration _configuration;
        public SensorServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Sensor>> GetSensors()
        {
            List<Sensor> sensors = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(_configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"Sensor/GetSensors");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                List<Sensor> res = await response.Content.ReadFromJsonAsync<List<Sensor>>();

                if (res != null)
                {
                    sensors = res;
                }
            }
            return sensors;
        }


        public async Task<Sensor> Create(Sensor sensor)
        {
            string url = _configuration.GetValue<string>("URL");

            HttpClient client = Helpers.Helpers.GetHttpClient(url);

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(sensor), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(url + $"sensor/create", httpContent);

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = JsonConvert.DeserializeObject<Sensor>(await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync());

                if (res != null)
                {
                    return res;
                }
            }
            return new Sensor();
        }


        //public static async Task<List<Sensor>> Edit(string sensorId, IConfiguration configuration)
        //{
        //    List<Sensor> sensors = new();

        //    HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

        //    HttpResponseMessage response = await client.GetAsync($"getapisensors?id={sensorId}");

        //    response.EnsureSuccessStatusCode();

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var res = await response.Content.ReadFromJsonAsync<List<Sensor>>();

        //        if (res != null)
        //        {
        //            sensors = res;
        //        }
        //    }
        //    return sensors;
        //}


        //public static async Task<List<Sensor>> ChangeState(string sensorId, IConfiguration configuration)
        //{
        //    List<Sensor> sensors = new();

        //    HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

        //    HttpResponseMessage response = await client.GetAsync($"getapisensors?id={sensorId}");

        //    response.EnsureSuccessStatusCode();

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var res = await response.Content.ReadFromJsonAsync<List<Sensor>>();

        //        if (res != null)
        //        {
        //            sensors = res;
        //        }
        //    }
        //    return sensors;
        //}
    }
}
