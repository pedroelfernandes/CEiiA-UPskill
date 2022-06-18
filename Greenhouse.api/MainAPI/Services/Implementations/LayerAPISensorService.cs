using MainAPI.Helpers.Interfaces;
using MainAPI.Models;
using MainAPI.Services.Interfaces;
using System.Net.Http.Headers;
using MyHTTPClient = MainAPI.Helpers.Implementations.HttpClHlp;

namespace MainAPI.Services.Implementations
{
    public class LayerAPISensorService : ILayerAPISensorService
    {
        private readonly IConfiguration _configuration;

        private readonly IHttpClHlp _httpClHlp;

        private readonly ILayerAPIJwtToken _layerAPIJwtToken;


        public LayerAPISensorService(IConfiguration configuration, IHttpClHlp httpClHlp, ILayerAPIJwtToken layerAPIJwtToken)
        {
            _configuration = configuration;
            _httpClHlp = httpClHlp;
            _layerAPIJwtToken = layerAPIJwtToken;
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

            HttpClient client = _httpClHlp.GetHttpClient(new Uri(storedURL.Url));

            string token = await _layerAPIJwtToken.GetToken(storedURL.Url);

            string url = storedURL.Url + "sensors/getallsensors";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

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
