using System.ComponentModel.DataAnnotations;

namespace TrainingAppBackend.Models
{
    public class Training
    {
        [Key]
        public int Id { get; set; }
        public int TypeId { get; set; }
        public TrainingType Type { get; set; }
        public String Duration { get; set; }
        [Range(1, 10)]
        public UInt16 Difficulty { get; set; }
        [Range(1, 10)]
        public UInt16 Tiredness { get; set; }
        public double CaloriesBurned { get; set; }
        public String Note { get; set; }
        public DateTime Created { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public Training()
        {
            Id = 0;
            TypeId = 0;
            Type = new TrainingType();
            Duration = String.Empty;
            Difficulty = 1;
            Tiredness = 1;
            CaloriesBurned = 0.0;
            Note = String.Empty;
            Created = DateTime.Now;
            UserId = 0;
            User = new User();
        }

        public Training(int id, int trainingTypeId, TrainingType type, string duration, ushort difficulty, ushort tiredness, double caloriesBurned, string note, DateTime created, int userId, User user)
        {
            Id = id;
            TypeId = trainingTypeId;
            Type = type;
            Duration = duration;
            Difficulty = difficulty;
            Tiredness = tiredness;
            CaloriesBurned = caloriesBurned;
            Note = note;
            Created = created;
            UserId = userId;
            User = user;
        }
    }
}
