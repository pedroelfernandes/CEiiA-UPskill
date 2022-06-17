namespace MainAPI.Services.Interfaces
{
    public interface ILayerAPIJwtToken
    {
        public Task<string> GetToken(string url);
    }
}
