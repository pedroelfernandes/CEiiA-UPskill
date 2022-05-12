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
    }
}
