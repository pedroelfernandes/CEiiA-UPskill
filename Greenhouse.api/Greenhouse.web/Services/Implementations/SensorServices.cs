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

        public async Task<List<Sensor>> Get()
        {
            List<Sensor> sensors = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(_configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"Sensor/Get");

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


        // Get role by id
        public async Task<Sensor> GetSensorById(int id)
        {
            Sensor sensor = new();
            string url = _configuration.GetValue<string>("URL");

            HttpClient client = Helpers.Helpers.GetHttpClient(url);

            HttpResponseMessage response = await client.GetAsync($"sensor/GetSensorById?id={id}");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                sensor = await response.Content.ReadFromJsonAsync<Sensor>();

                if (sensor == null)
                {
                    throw new Exception("Sensor not found.");
                }
            }
            return sensor;
        }


        // Create new sensor
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



        //Edit a specific Sensor 
        public async Task<Sensor> Edit(Sensor sensor)
        {
            string url = _configuration.GetValue<string>("URL");

            HttpClient client = Helpers.Helpers.GetHttpClient(url);
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(sensor), Encoding.UTF8);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync(url + $"sensor/edit", httpContent);

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

        // Change state from true to false and vice versa for sensors
        public async Task<bool> ChangeState(int id)
        {
            Sensor sensor = new();

            string url = _configuration.GetValue<string>("URL");

            HttpClient client = Helpers.Helpers.GetHttpClient(url);
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(sensor), Encoding.UTF8);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync(url + $"sensor/ChangeState?id={id}", httpContent);

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<bool>(await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync());
            }
            return false;
        }
    }
}
