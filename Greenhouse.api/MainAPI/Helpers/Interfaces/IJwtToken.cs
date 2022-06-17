namespace MainAPI.Helpers.Interfaces
{
    public interface IJwtToken
    {
        public string GenerateJwtToken(string username);
    }
}
