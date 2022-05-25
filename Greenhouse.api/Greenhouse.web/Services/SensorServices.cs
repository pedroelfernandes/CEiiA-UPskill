using Greenhouse.web.Models;

namespace Greenhouse.web.Services
{
    public class SensorServices
    {
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
    }
}
