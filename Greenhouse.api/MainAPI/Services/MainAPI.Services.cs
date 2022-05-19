using MainAPI.Data;
using MainAPI.DTO;
using MainAPI.Models;
using MainAPI.Repositories;
using MyHttpClient = MainAPI.HttpClientHelper;

namespace MainAPI.Services
{
    public class Services
    {
        private readonly IConfiguration _configuration;
        private readonly APIRepository _apiRepository;


        public Services(IConfiguration configuration, APIRepository apiRepository)
        {
            _configuration = configuration;
            _apiRepository = apiRepository;
        }


        public static System.Uri GetAPIUrl(string id, IConfiguration configuration)
        {
            List<StoredURL> storedURLs = configuration.GetSection("URL-Section:URLs").Get<List<StoredURL>>();
            System.Uri url = new(storedURLs.Find(u => u.Id == id).Url);
            return url;
        }


        public static async Task<IEnumerable<Reading>> GetLastByAPI(string id, IConfiguration configuration)
        {
            IEnumerable<Reading> readings = new List<Reading>();

            System.Uri uri = GetAPIUrl(id, configuration);
            HttpClient client = MyHttpClient.HttpClHlp.GetHttpClient(uri);

            HttpResponseMessage response = await client.GetAsync("getlast");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                List<Reading>? res = await response.Content.ReadFromJsonAsync<List<Reading>>();

                if (res != null)
                    readings = res;
            }

            return readings;
        }



        public static async Task<Reading> GetLastByAPIBySensorId(string id, int sensorId, IConfiguration configuration)
        {
            Reading reading = new();

            System.Uri uri = GetAPIUrl(id, configuration);
            HttpClient client = MyHttpClient.HttpClHlp.GetHttpClient(uri);

            HttpResponseMessage response = await client.GetAsync($"getlastbysensorid?id={sensorId}");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                Reading? res = await response.Content.ReadFromJsonAsync<Reading>();

                if (res != null)
                    reading = res;
            }

            return reading;
        }


        public static async Task<IEnumerable<Reading>> GetLastValuesBySensorId(string id, int sensorId, int limit, IConfiguration configuration)
        {
            IEnumerable<Reading> readings = new List<Reading>();

            System.Uri uri = GetAPIUrl(id, configuration);
            HttpClient client = MyHttpClient.HttpClHlp.GetHttpClient(uri);

            HttpResponseMessage response = await client.GetAsync($"getlastvaluesbysensorid?id={sensorId}&limit={limit}");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                List<Reading>? res = await response.Content.ReadFromJsonAsync<List<Reading>>();

                if (res != null)
                    readings = res;
            }

            return readings;
        }


        public static async Task<IEnumerable<SensorDTO>> GetAPISensors(string id, IConfiguration configuration)
        {
            IEnumerable<SensorDTO> sensors = new List<SensorDTO>();

            System.Uri uri = GetAPIUrl(id, configuration);
            HttpClient client = MyHttpClient.HttpClHlp.GetHttpClient(uri);

            HttpResponseMessage response = await client.GetAsync("getsensors");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                List<SensorDTO>? res = await response.Content.ReadFromJsonAsync<List<SensorDTO>>();

                if (res != null)
                    sensors = res;
            }

            return sensors;
        }


        public static async Task<IEnumerable<APIDTO>> GetAPIs(APIRepository apiRepository)
        {
            IEnumerable<API> APIs = new List<API>();

            APIs = apiRepository.GetAPIs();

            if (APIs is null)
                throw new Exception("No APIs found.");

            IEnumerable<APIDTO> res = APIs.Select(api => APIDTO.ToDto(api)).ToList();

            return res;
        }
    }
}
