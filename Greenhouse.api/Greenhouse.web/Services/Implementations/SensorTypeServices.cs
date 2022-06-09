using Greenhouse.web.Models;
using Greenhouse.web.Services.Interfaces;

namespace Greenhouse.web.Services.Implementations
{
    public class SensorTypeServices: ISensorTypeServices
    {
        private readonly IConfiguration _configuration;

        public SensorTypeServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<SensorType>> GetSensorTypes()
        {
            List<SensorType> sensorTypes = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(_configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync("SensorType/GetSensorTypes");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadFromJsonAsync<List<SensorType>>();

                if (res != null)
                {
                    sensorTypes = res;
                }
            }
            return sensorTypes;
        }



        //public static async Task<List<SensorType>> Create(string sensorTypeId, IConfiguration configuration)
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
