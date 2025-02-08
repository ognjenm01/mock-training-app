using System.Security.Claims;

namespace TrainingAppBackend.Services
{
    public interface IJwtService
    {
        public string GenerateToken(int id, string username);

        public ClaimsPrincipal? VerifyToken(string token);
    }
}
