using TrainingAppBackend.Models;

namespace TrainingAppBackend.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetById(int id);
        Task AddUser(User user);

    }
}
