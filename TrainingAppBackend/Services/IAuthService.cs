

using TrainingAppBackend.DTO;

namespace TrainingAppBackend.Services
{
    public interface IAuthService
    {
        Task<JwtDTO?> Login(LoginRequestDTO request);
        Task<JwtDTO?> Register(RegisterRequestDTO request);
    }
}
