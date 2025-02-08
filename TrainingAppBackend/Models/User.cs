using System.ComponentModel.DataAnnotations;

namespace TrainingAppBackend.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public List<Training> Trainings { get; set; }

        public User()
        {
            Id = 0;
            Email = string.Empty;
            Password = string.Empty;
            Trainings = new List<Training>();
        }

        public User(int id, string email, string password, List<Training> trainings)
        {
            Id = id;
            Email = email;
            Password = password;
            Trainings = trainings;
        }   
    }
}
