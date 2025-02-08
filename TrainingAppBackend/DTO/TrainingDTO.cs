using System.ComponentModel.DataAnnotations;
using TrainingAppBackend.Models;

namespace TrainingAppBackend.DTO
{
    public class TrainingDTO
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public TrainingTypeDTO Type { get; set; }
        public String Duration { get; set; }
        public UInt16 Difficulty { get; set; }
        public UInt16 Tiredness { get; set; }
        public double CaloriesBurned { get; set; }
        public String Note { get; set; }
        public DateTime Created { get; set; }
        public int UserId { get; set; }

        public TrainingDTO(int id, int typeId, TrainingTypeDTO type, string duration, ushort difficulty, ushort tiredness, double caloriesBurned, string note, DateTime created, int userId)
        {
            Id = id;
            TypeId = typeId;
            Type = type;
            Duration = duration;
            Difficulty = difficulty;
            Tiredness = tiredness;
            CaloriesBurned = caloriesBurned;
            Note = note;
            Created = created;
            UserId = userId;
        }
    }
}
