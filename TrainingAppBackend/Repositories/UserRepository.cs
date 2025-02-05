using Microsoft.EntityFrameworkCore;
using TrainingAppBackend.Context;
using TrainingAppBackend.Models;

namespace TrainingAppBackend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> GetByUsername(string username)
        {
            return await _context.Users.FirstAsync(u => u.Email == username);
        }

        public async Task<int> GetMaxId()
        {
            return await _context.Users.AnyAsync() ? await _context.Users.MaxAsync(i =>  i.Id) : 0;
        }
    }
}
