using System.ComponentModel.DataAnnotations;

namespace TrainingAppBackend.Models
{
    public class TrainingType
    {
        [Key]
        public int Id {  get; set; }

        [Required]
        public String Name { get; set; }

        public List<Training> Trainings { get; set; }

        public TrainingType()
        {
            Id = 0;
            Name = String.Empty;
            Trainings = new List<Training>();
        }
        public TrainingType(int id, string name, List<Training> trainings)
        {
            Id = id;
            Name = name;
            Trainings = trainings;
        }
    }
}
