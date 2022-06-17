using MainAPI.HttpClientHelper;
using MainAPI.Services.Interfaces;

namespace MainAPI.Services.Implementations
{
    public class LayerAPIJwtToken : ILayerAPIJwtToken
    {
        private readonly IHttpClHlp _httpClHlp;


        public LayerAPIJwtToken(IHttpClHlp httpClHlp)
        {
            _httpClHlp = httpClHlp;
        }


        public async Task<string> GetToken(string url)
        {
            string token = string.Empty;

            HttpClient client = _httpClHlp.GetHttpClient(new Uri(url));

            HttpResponseMessage response = await client.GetAsync("jwt/gettoken");

            response.EnsureSuccessStatusCode();

            if(response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadFromJsonAsync<string>();

                if (res != null)
                    token = res;
            }

            return token;
        }
    }
}
