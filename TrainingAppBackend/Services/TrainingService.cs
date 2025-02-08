using TrainingAppBackend.DTO;
using TrainingAppBackend.Models;
using TrainingAppBackend.Repositories;

namespace TrainingAppBackend.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _repo;

        public TrainingService(ITrainingRepository repo)
        {
            _repo = repo;
        }

        public async Task<TrainingDTO?> AddTraining(TrainingDTO dto)
        {
            await _repo.AddTraining(new Training(0, dto.TypeId, null, dto.Duration, dto.Difficulty, dto.Tiredness, dto.CaloriesBurned, dto.Note, dto.Created, dto.UserId, null));

            return dto;
        }

        public async Task<IEnumerable<TrainingDTO?>> GetAll()
        {
            List<TrainingDTO> dtos = new List<TrainingDTO>();
            var trainings = await _repo.GetAll();

            foreach (Training t in trainings)
            {
                dtos.Add(new TrainingDTO(t.Id, t.Type.Id, new TrainingTypeDTO(t.Type.Id, t.Type.Name), t.Duration, t.Difficulty, t.Tiredness, t.CaloriesBurned, t.Note, t.Created, t.UserId));
            }

            return dtos;
        }

        public async Task<TrainingDTO?> GetById(int id)
        {
            var t = await (_repo.GetById(id));
            return new TrainingDTO(t.Id, t.Type.Id, new TrainingTypeDTO(t.Type.Id, t.Type.Name), t.Duration, t.Difficulty, t.Tiredness, t.CaloriesBurned, t.Note, t.Created, t.UserId);
        }

        public async Task<IEnumerable<TrainingDTO?>> GetByMonth(int month, int userId)
        {
            //Can be expanded to include year
            var allTrainings = await GetAll();
            return allTrainings.Where(t => t.Created.Month == month && t.UserId == userId).ToList();
        }
    }
}
