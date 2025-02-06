using Microsoft.EntityFrameworkCore;
using TrainingAppBackend.Context;
using TrainingAppBackend.Models;

namespace TrainingAppBackend.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly ApplicationDbContext _context;

        public TrainingRepository(ApplicationDbContext context) 
        {
            _context = context; 
        }

        public async Task<Training?> AddTraining(Training training)
        {
            _context.Trainings.Add(training);
            await _context.SaveChangesAsync();
            return training;
        }

        public async Task<IEnumerable<Training?>> GetAll()
        {
            return await _context.Trainings.ToListAsync();
        }

        public async Task<Training?> GetById(int id)
        {
            return await _context.Trainings.FindAsync(id);
        }
    }
}
