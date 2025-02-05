using System.ComponentModel.DataAnnotations;

namespace TrainingAppBackend.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User()
        {
            Id = 0;
            Email = string.Empty;
            Password = string.Empty;
        }

        public User(int id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }   
    }
}
