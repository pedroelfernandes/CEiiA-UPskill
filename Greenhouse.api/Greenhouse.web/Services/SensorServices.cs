using Greenhouse.web.Models;

namespace Greenhouse.web.Services
{
    public class SensorServices
    {
        public static async Task<List<Sensor>> Get(string sensorId, IConfiguration configuration)
        {
            List<Sensor> sensors = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"getapisensors?id={sensorId}");

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


        public static async Task<List<Sensor>> Create(string sensorId, IConfiguration configuration)
        {
            List<Sensor> sensors = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"getapisensors?id={sensorId}");

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


        public static async Task<List<Sensor>> Edit(string sensorId, IConfiguration configuration)
        {
            List<Sensor> sensors = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"getapisensors?id={sensorId}");

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


        public static async Task<List<Sensor>> ChangeState(string sensorId, IConfiguration configuration)
        {
            List<Sensor> sensors = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"getapisensors?id={sensorId}");

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
    }
}
