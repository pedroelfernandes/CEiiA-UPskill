using System.Net.Http.Headers;

namespace Greenhouse.web.Helpers
{
    public static class Helpers
    { 
        public static HttpClient GetHttpClient(string url)
        {
            HttpClient client = new();

            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
