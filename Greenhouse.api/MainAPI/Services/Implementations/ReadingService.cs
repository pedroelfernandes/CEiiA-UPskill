using MainAPI.Models;
using MainAPI.Services.Interfaces;
using MyHTTPClient = MainAPI.HttpClientHelper.HttpClHlp;

namespace MainAPI.Services.Implementations
{
    public class ReadingService : IReadingService
    {
        private readonly IConfiguration _configuration;


        public ReadingService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<IReadOnlyList<Reading>> GetBySensorId(int urlId, string sensorId, int size)
        {
            List<Reading> readings = new();

            System.Uri url = MyHTTPClient.GetAPIUrl(urlId, _configuration);
            HttpClient httpClient = MyHTTPClient.GetHttpClient(url);

            HttpResponseMessage response = await httpClient.GetAsync($"readings/getbysensorid?sensorid={sensorId}&size={size}");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                List<Reading> res = await response.Content.ReadFromJsonAsync<List<Reading>>();

                if (res != null)
                    readings = res;
            }

            return readings;
        }


        public async Task<IReadOnlyList<Reading>> GetBetweenDatesBySensorId(int urlId, string sensorId, DateTime startDate, DateTime endDate)
        {
            List<Reading> readings = new();

            System.Uri url = MyHTTPClient.GetAPIUrl(urlId, _configuration);
            HttpClient httpClient = MyHTTPClient.GetHttpClient(url);

            HttpResponseMessage response = await httpClient.GetAsync($"readings/getbetweendatesbysensorid?sensorid={sensorId}&startdate={startDate}&enddate={endDate}");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                List<Reading> res = await response.Content.ReadFromJsonAsync<List<Reading>>();

                if (res != null)
                    readings = res;
            }

            return readings;
        }
    }
}
