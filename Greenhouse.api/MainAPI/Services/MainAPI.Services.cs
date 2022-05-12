using MainAPI.Data;
using MainAPI.Models;
using MyHttpClient = MainAPI.HttpClientHelper;

namespace MainAPI.Services
{
    public class Services
    {
        private readonly ApplicationDbContext _db;



        public Services(ApplicationDbContext db)
        {
            _db = db;
        }



        public static async Task<IEnumerable<Reading>> GetLastByAPI(Uri uri)
        {
            IEnumerable<Reading> readings = new List<Reading>();

            HttpClient client = MyHttpClient.HttpClHlp.GetHttpClient(uri);

            HttpResponseMessage response = await client.GetAsync("getlast");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadFromJsonAsync<List<Reading>>();

                if (res != null)
                    readings = res;
            }

            return readings;
        }



        public static async Task<Reading> GetLastByAPIBySensorId(Uri uri, int id)
        {
            Reading reading = new();

            HttpClient client = MyHttpClient.HttpClHlp.GetHttpClient(uri);

            HttpResponseMessage response = await client.GetAsync($"getlastbysensorid?id={id}");

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadFromJsonAsync<Reading>();

                if (res != null)
                    reading = res;
            }

            return reading;
        }
    }
}
