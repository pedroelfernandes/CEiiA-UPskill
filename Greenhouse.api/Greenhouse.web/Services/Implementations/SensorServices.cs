using Greenhouse.web.Models;
using Greenhouse.web.Services.Interfaces;

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
                var res = await response.Content.ReadFromJsonAsync<List<Sensor>>();

                if (res != null)
                {
                    sensors = res;
                }
            }
            return sensors;
        }


        //public static async Task<List<Sensor>> Create(string sensorId, IConfiguration configuration)
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
