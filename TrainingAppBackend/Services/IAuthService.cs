

using TrainingAppBackend.DTO;

namespace TrainingAppBackend.Services
{
    public interface IAuthService
    {
        Task<String?> Login(LoginRequestDTO request);
        Task<String?> Register(RegisterRequestDTO request);
    }
}
