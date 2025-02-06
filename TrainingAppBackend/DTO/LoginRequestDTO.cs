using System.ComponentModel.DataAnnotations;

namespace TrainingAppBackend.DTO
{
    public class LoginRequestDTO
    {
        public required String Username { get; set; }
        public required String Password { get; set; }
    }
}
