using TrainingAppBackend.Models;
using TrainingAppBackend.Repositories;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingAppBackend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<User?> AddUser(User user)
        {
            var existingUser = await GetByUsername(user.Email);
            if (existingUser == null)
                return await _repo.AddUser(user);
            return null;
        }

        public async Task<User?> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<User?> GetByUsername(string username)
        {
            try
            {
                return await _repo.GetByUsername(username);
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<int> GetMaxId()
        {
            return _repo.GetMaxId();
        }
    }
}
