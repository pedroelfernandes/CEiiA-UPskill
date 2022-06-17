using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WeatherStation.api.JwtHelper
{
    public class JwtToken : IJwtToken
    {
        private readonly string SECRET_KEY;
        
        private readonly IConfiguration _configuration;
        
        public readonly SymmetricSecurityKey SIGNING_KEY;


        public JwtToken(IConfiguration configuration)
        {
            _configuration = configuration;

            SECRET_KEY = _configuration.GetValue<string>("SECRET_KEY");

            SIGNING_KEY = new(Encoding.UTF8.GetBytes(SECRET_KEY));
        }

        public string GenerateJwtToken()
        {
            SigningCredentials credentials = new(SIGNING_KEY, SecurityAlgorithms.HmacSha256);

            JwtHeader header = new(credentials);

            DateTime expireDate = DateTime.UtcNow.AddMinutes(5);

            int ts = (int)(expireDate - new DateTime(1970, 1, 1)).TotalSeconds;

            string IssAud = _configuration.GetValue<string>("SSL_URL");

            JwtPayload payload = new()
            {
                { "exp", ts },
                { "iss", IssAud },
                { "aud", IssAud }
            };

            JwtSecurityToken securityToken = new(header, payload);

            JwtSecurityTokenHandler securityTokenHandler = new();

            string token = securityTokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
