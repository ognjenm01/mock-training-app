using TrainingAppBackend.Models;

namespace TrainingAppBackend.Repositories
{
    public interface ITrainingTypeRepository
    {
        Task<TrainingType?> GetById(int id);
        Task<IEnumerable<TrainingType?>> GetAll();
    }
}
