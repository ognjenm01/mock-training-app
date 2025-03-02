﻿using TrainingAppBackend.Models;

namespace TrainingAppBackend.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetById(int id);
        Task<IEnumerable<User>> GetAll();
        Task<User?> AddUser(User user);
        Task <User?> GetByUsername(string username);
        Task<int> GetMaxId();

    }
}
