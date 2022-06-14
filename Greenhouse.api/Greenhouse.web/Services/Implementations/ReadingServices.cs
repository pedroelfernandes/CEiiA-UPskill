using Greenhouse.web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.web.Services.Implementations
{
    public class ReadingServices
    {
        public static async Task<List<Reading>> GetLastByAPI(string apiId, IConfiguration configuration)
        {
            List<Reading> reading = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"getlastbyapi?id={apiId}");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadFromJsonAsync<List<Reading>>();

                if (res != null)
                {
                    reading = res;
                }
            }
            return reading;
        }

        public static async Task<Reading> GetLastSensorValue(string apiId, string sensorId, IConfiguration configuration)
        {
            Reading reading = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"getlastbyapibysensorid?id={apiId}&sensorId={sensorId}");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadFromJsonAsync<Reading>();

                if (res != null)
                {
                    reading = res;
                }
            }
            return reading;
        }

        public static async Task<List<Reading>> GetLastValuesBySensorId(string apiId, string sensorId, string limit, IConfiguration configuration)
        {
            List<Reading> reading = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"getlastvaluesbysensorid?id={apiId}&sensorId={sensorId}&limit={limit}");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadFromJsonAsync<List<Reading>>();

                if (res != null)
                {
                    reading = res;
                }
            }
            return reading;
        }

        public static async Task<List<Sensor>> GetAPISensors(string apiId, IConfiguration configuration)
        {
            List<Sensor> sensors = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"getapisensors?id={apiId}");

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

        //public static async Task<IEnumerable<API>> GetAPI(IConfiguration configuration)
        //{
        //    IEnumerable<API> apis = new List<API>();

        //    string apiId = configuration.GetValue<string>("URI");

        //    HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URI"));

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
        //}

    }
}
