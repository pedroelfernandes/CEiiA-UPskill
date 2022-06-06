namespace Greenhouse.web.Services
{
    public class SensorTypeServices
    {
        public static async Task<List<SensorType>> Get(string sensorTypeId, IConfiguration configuration)
        {
            List<SensorType> sensorTypes = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"getapisensors?id={sensorTypeId}");

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

        public static async Task<List<SensorType>> Create(string sensorTypeId, IConfiguration configuration)
        {
            List<SensorType> sensorTypes = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"getapisensors?id={sensorTypeId}");

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


        public static async Task<List<SensorType>> Edit(string sensorTypeId, IConfiguration configuration)
        {
            List<SensorType> sensorTypes = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"getapisensors?id={sensorTypeId}");

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


        public static async Task<List<SensorType>> ChangeState(string sensorTypeId, IConfiguration configuration)
        {
            List<SensorType> sensorTypes = new();

            HttpClient client = Helpers.Helpers.GetHttpClient(configuration.GetValue<string>("URL"));

            HttpResponseMessage response = await client.GetAsync($"getapisensors?id={sensorTypeId}");

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
    }
}
