using MainAPI.Models;
using System.Net.Http.Headers;

namespace MainAPI.HttpClientHelper
{
    public class HttpClHlp
    {
        public static HttpClient GetHttpClient(Uri url)
        {
            HttpClient client = new();

            client.BaseAddress = url;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }


        public static System.Uri GetAPIUrl(int id, IConfiguration configuration)
        {
            List<StoredURL> storedURLs = configuration.GetSection("URL-Section:URLs").Get<List<StoredURL>>();

            System.Uri url = new(storedURLs.Find(url => url.Id == id).Url);

            if (url == null)
                throw new Exception("URL id not defined.");

            return url;
        }
    }
}
