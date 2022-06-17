using MainAPI.Models;
using System.Net.Http.Headers;

namespace MainAPI.HttpClientHelper
{
    public class HttpClHlp : IHttpClHlp
    {
        private readonly IConfiguration _configuration;


        public HttpClHlp(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public HttpClient GetHttpClient(Uri url)
        {
            HttpClient client = new();

            client.BaseAddress = url;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }


        public Uri GetAPIUrl(int id)
        {
            List<StoredURL> storedURLs = _configuration.GetSection("URL-Section:URLs").Get<List<StoredURL>>();

            Uri url = new(storedURLs.Find(url => url.Id == id).Url);

            if (url == null)
                throw new Exception("URL id not defined.");

            return url;
        }
    }
}
