using TrainingAppBackend.DTO;
using TrainingAppBackend.Models;

namespace TrainingAppBackend.Services
{
    public interface ITrainingTypeService
    {
        Task<TrainingTypeDTO?> GetById(int id);
        Task<IEnumerable<TrainingTypeDTO?>> GetAll();
    }
}
