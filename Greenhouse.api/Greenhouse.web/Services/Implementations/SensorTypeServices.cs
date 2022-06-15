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
        public async Task<SensorType> GetById(int id)
        {
            SensorType sensorType = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(_configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync("SensorType/Get ? id ={ sensorTypeId}");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadFromJsonAsync<SensorType>();

                if (res != null)
                {
                    sensorType = res;
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


        //public static async Task<List<SensorType>> Edit(string sensorTypeId, IConfiguration configuration)
        //{
        //    List<SensorType> sensorTypes = new();

        //    HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

        //    HttpResponseMessage response = await client.GetAsync($"getapisensors?id={sensorTypeId}");

        //    response.EnsureSuccessStatusCode();

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var res = await response.Content.ReadFromJsonAsync<List<SensorType>>();

        //        if (res != null)
        //        {
        //            sensorTypes = res;
        //        }
        //    }
        //    return sensorTypes;
        //}


        //public static async Task<List<SensorType>> ChangeState(string sensorTypeId, IConfiguration configuration)
        //{
        //    List<SensorType> sensorTypes = new();

        //    HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

        //    HttpResponseMessage response = await client.GetAsync($"getapisensors?id={sensorTypeId}");

        //    response.EnsureSuccessStatusCode();

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var res = await response.Content.ReadFromJsonAsync<List<SensorType>>();

        //        if (res != null)
        //        {
        //            sensorTypes = res;
        //        }
        //    }
        //    return sensorTypes;
        //}
    }
}
