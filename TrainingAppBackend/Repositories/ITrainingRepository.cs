using TrainingAppBackend.Models;

namespace TrainingAppBackend.Repositories
{
    public interface ITrainingRepository
    {
        Task<Training?> GetById(int id);
        Task<IEnumerable<Training?>> GetAll();
        Task<Training?> AddTraining(Training training);
    }
}
