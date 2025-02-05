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

        public async Task AddUser(User user)
        {
            int id = GetMaxId().Result + 1;
            user.Id = id;

            //Hash password + salt using ID
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: user.Password,
            salt: BitConverter.GetBytes(id),
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

            user.Password = hashed;

            await _repo.AddUser(user);
        }

        public async Task<User?> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        public Task<int> GetMaxId()
        {
            return _repo.GetMaxId();
        }
    }
}
