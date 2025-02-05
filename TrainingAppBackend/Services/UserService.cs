using TrainingAppBackend.Models;
using TrainingAppBackend.Repositories;

namespace TrainingAppBackend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task AddUser(User user)
        {
            await _repo.AddUser(user);
        }

        public async Task<User?> GetById(int id)
        {
            return await _repo.GetById(id);
        }
    }
}
