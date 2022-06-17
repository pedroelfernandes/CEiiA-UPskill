namespace MainAPI.Helpers.Interfaces
{
    public interface IHttpClHlp
    {
        public HttpClient GetHttpClient(Uri url);


        public Uri GetAPIUrl(int id);
    }
}
