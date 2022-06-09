using MainAPI.Models;
using MainAPI.Services.Interfaces;
using MyHTTPClient = MainAPI.HttpClientHelper.HttpClHlp;

namespace MainAPI.Services.Implementations
{
    public class LayerAPISensorService : ILayerAPISensorService
    {
        private readonly IConfiguration _configuration;


        public LayerAPISensorService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        //adjust this method to use GetAPISensors() recursively
        public async Task<IReadOnlyList<Sensor>> GetSensors()
        {
            List<Sensor> sensors = new();

            IReadOnlyList<StoredURL> storedURLs = _configuration.GetSection("URL-Section:URLs").Get<List<StoredURL>>();

            foreach (StoredURL url in storedURLs)
                sensors.AddRange(await GetAPISensors(url));

            return sensors;
        }


        //change this method to return a List<Sensor>
        public async Task<List<Sensor>> GetAPISensors(StoredURL storedURL)
        {
            List<LayerSensor> sensors = new();

            HttpClient client = MyHTTPClient.GetHttpClient(new Uri(storedURL.Url));

            HttpResponseMessage response = await client.GetAsync("sensors/getallsensors");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                List<LayerSensor> res = await response.Content.ReadFromJsonAsync<List<LayerSensor>>();

                if (res != null)
                    sensors = res;
            }

            List<Sensor> sensors1 = sensors.Select(s => Sensor.ToSensor(s)).ToList();

            foreach (Sensor sensor in sensors1)
                sensor.URLId = storedURL.Id;

            return sensors1;
        }
    }
}
