using Greenhouse.web.Models;
using Greenhouse.web.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Greenhouse.web.Services.Implementations
{
    public class SensorTypeServices: ISensorTypeServices
    {
        private readonly IConfiguration _configuration;

        public SensorTypeServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        //Get full list of SensorTypes - NOT IMPLEMENTED IN MAIN API
        public async Task<List<SensorType>> Get()
        {
            List<SensorType> sensorTypes = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(_configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync("SensorType/Get");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                List<SensorType> res = await response.Content.ReadFromJsonAsync<List<SensorType>>();

                if (res != null)
                {
                    sensorTypes = res;
                }
            }
            return sensorTypes;
        }


        //Get sensortype by Id
        public async Task<SensorType> GetSensorTypeById(int id)
        {
            SensorType sensorType = new();

            string url = _configuration.GetValue<string>("URL");

            HttpClient client = Helpers.Helpers.GetHttpClient(url);

            HttpResponseMessage response = await client.GetAsync($"SensorType/GetSensorTypeById?id={id}");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                sensorType = await response.Content.ReadFromJsonAsync<SensorType>();

                if (sensorType == null)
                {
                    throw new Exception("Sensor Type not found.");
                }
            }
            return sensorType;
        }


        // Create new sensor type
        public async Task<SensorType> Create(SensorType sensorType)
        {
            string url = _configuration.GetValue<string>("URL");

            HttpClient client = Helpers.Helpers.GetHttpClient(url);

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(sensorType), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(url + $"sensortype/create", httpContent);

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = JsonConvert.DeserializeObject<SensorType>(await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync());

                if (res != null)
                {
                    return res;
                }
            }
            return new SensorType();
        }


        public  async Task<SensorType> Edit(SensorType sensorType)
        {
            string url = _configuration.GetValue<string>("URL");

            HttpClient client = Helpers.Helpers.GetHttpClient(url);
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(sensorType), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync(url + $"sensortype/edit", httpContent);

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = JsonConvert.DeserializeObject<SensorType>(await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync());

                if (res != null)
                {
                    return res;
                }
            }
            return new SensorType();
        }


        //Delete-change status sensorType(bool)
        public async Task<bool> ChangeState(int id)
        {
            SensorType sensorType = new();

            string url = _configuration.GetValue<string>("URL");

            HttpClient client = Helpers.Helpers.GetHttpClient(url);
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(sensorType), Encoding.UTF8);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync(url + $"sensorType/ChangeState?id={id}", httpContent);
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<bool>(await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync());
            }
            return false;
        }
    }
}
