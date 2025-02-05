using TrainingAppBackend.Models;

namespace TrainingAppBackend.Services
{
    public interface IUserService
    {
        Task<User?> GetById(int id);
        Task AddUser(User user);
        Task<User?> GetByUsername(string username);
        Task<int> GetMaxId();
    }
}
