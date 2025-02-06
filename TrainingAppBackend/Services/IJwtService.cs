using System.Security.Claims;

namespace TrainingAppBackend.Services
{
    public interface IJwtService
    {
        public string GenerateToken(string username);

        public ClaimsPrincipal? VerifyToken(string token);
    }
}
