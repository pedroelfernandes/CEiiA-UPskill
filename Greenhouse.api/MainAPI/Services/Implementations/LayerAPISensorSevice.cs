using MainAPI.Models;
using MainAPI.Services.Interfaces;
using MyHTTPClient = MainAPI.HttpClientHelper.HttpClHlp;

namespace MainAPI.Services.Implementations
{
    public class LayerAPISensorSevice : ILayerAPISensorService
    {
        private readonly IConfiguration _configuration;


        public LayerAPISensorSevice(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<IReadOnlyList<LayerSensor>> GetSensors()
        {
            List<LayerSensor> sensors = new();

            IReadOnlyList<StoredURL> storedURLs = _configuration.GetSection("URL-Section:URLs").Get<List<StoredURL>>();

            foreach (StoredURL url in storedURLs)
            {
                HttpClient client = MyHTTPClient.GetHttpClient(new Uri(url.Url));

                HttpResponseMessage response = await client.GetAsync("sensors/getallsensors");

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    List<LayerSensor> res = await response.Content.ReadFromJsonAsync<List<LayerSensor>>();

                    if (res != null)
                        sensors.AddRange(res);
                }
            }

            return sensors;
        }
    }
}
