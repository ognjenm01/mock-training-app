using Moq;
using TrainingAppBackend.Services;
using TrainingAppBackend.Models;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace TrainingAppBackend.Tests
{
    public class JwtServiceTests
    {
        private readonly IOptions<JwtSettings> _mockJwtSettings;

        public JwtServiceTests()
        {
            var jwtSettings = new JwtSettings
            {
                SecurityKey = "MySuperSecretKeyMySuperSecretKeyMySuperSecretKeyMySuperSecretKeyMySuperSecretKeyMySuperSecretKey",
                Issuer = "MyIssuer",
                Audience = "MyAudience",
                ExpirationTimeInMinutes = 60
            };

            _mockJwtSettings = Options.Create(jwtSettings);
        }



        [Fact]
        public void GenerateToken_ValidUser_ReturnsValidToken()
        {
            var jwtService = new JwtService(_mockJwtSettings);
            String username = "Oggy";

            var token = jwtService.GenerateToken(username);

            Assert.NotNull(token);
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
            Assert.NotNull(jsonToken);
            Assert.Equal("Oggy", jsonToken?.Claims.First(c => c.Type == ClaimTypes.Name).Value);
        }
    }
}
