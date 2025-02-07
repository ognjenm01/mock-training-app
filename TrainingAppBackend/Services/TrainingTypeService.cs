using TrainingAppBackend.DTO;
using TrainingAppBackend.Models;
using TrainingAppBackend.Repositories;

namespace TrainingAppBackend.Services
{
    public class TrainingTypeService : ITrainingTypeService
    {
        private readonly ITrainingTypeRepository _repo;

        public TrainingTypeService(ITrainingTypeRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<TrainingTypeDTO?>> GetAll()
        {
            List<TrainingTypeDTO> dtos = new List<TrainingTypeDTO>();
            var trainingTypes = await _repo.GetAll();
            
            foreach (TrainingType t in trainingTypes)
                dtos.Add(new TrainingTypeDTO(t.Id, t.Name));

            return dtos;
        }

        public async Task<TrainingTypeDTO?> GetById(int id)
        {
            var trainingType =  await _repo.GetById(id);
            return new TrainingTypeDTO(trainingType.Id, trainingType.Name);
        }
    }
}
