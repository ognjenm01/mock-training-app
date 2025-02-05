using TrainingAppBackend.Models;

namespace TrainingAppBackend.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetById(int id);

        Task<IEnumerable<User>> GetAll();
        Task AddUser(User user);

        Task<int> GetMaxId();

    }
}
