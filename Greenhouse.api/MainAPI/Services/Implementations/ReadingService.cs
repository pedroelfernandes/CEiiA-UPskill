using MainAPI.HttpClientHelper;
using MainAPI.Models;
using MainAPI.Services.Interfaces;
using System.Net.Http.Headers;
using MyHTTPClient = MainAPI.HttpClientHelper.HttpClHlp;

namespace MainAPI.Services.Implementations
{
    public class ReadingService : IReadingService
    {
        private readonly IConfiguration _configuration;

        private readonly IHttpClHlp _httpClHlp;

        private readonly ILayerAPIJwtToken _layerAPIJwtToken;


        public ReadingService(IConfiguration configuration, IHttpClHlp httpClHlp, ILayerAPIJwtToken layerAPIJwtToken)
        {
            _configuration = configuration;
            _httpClHlp = httpClHlp;
            _layerAPIJwtToken = layerAPIJwtToken;
        }


        public async Task<IReadOnlyList<Reading>> GetBySensorId(int urlId, string sensorId, int size)
        {
            List<Reading> readings = new();

            Uri url = _httpClHlp.GetAPIUrl(urlId);

            HttpClient httpClient = _httpClHlp.GetHttpClient(url);

            string token = await _layerAPIJwtToken.GetToken(url.ToString());

            string urlString = url.ToString() + $"readings/getbysensorid?sensorid={sensorId}&size={size}";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, urlString);

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

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

            Uri url = _httpClHlp.GetAPIUrl(urlId);

            HttpClient httpClient = _httpClHlp.GetHttpClient(url);

            string token = await _layerAPIJwtToken.GetToken(url.ToString());

            string urlString = url.ToString() + $"readings/getbetweendatesbysensorid?sensorid={sensorId}&startdate={startDate}&enddate={endDate}";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, urlString);

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

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
