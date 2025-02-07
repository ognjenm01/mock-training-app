using Microsoft.EntityFrameworkCore;
using TrainingAppBackend.Context;
using TrainingAppBackend.Models;

namespace TrainingAppBackend.Repositories
{
    public class TrainingTypeRepository : ITrainingTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public TrainingTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TrainingType>> GetAll()
        {
            return await _context.TrainingTypes.ToListAsync();
        }

        public async Task<TrainingType?> GetById(int id)
        {
            return await _context.TrainingTypes.FindAsync(id);
        }
    }
}
