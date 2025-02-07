using TrainingAppBackend.DTO;
using TrainingAppBackend.Models;

namespace TrainingAppBackend.Services
{
    public interface ITrainingService
    {
        Task<TrainingDTO?> GetById(int id);
        Task<IEnumerable<TrainingDTO?>> GetAll();
        Task<TrainingDTO?> AddTraining(TrainingDTO training);
    }
}
