namespace TrainingAppBackend.DTO
{
    //This can be later expanded upon if more data is required from user when registering.
    public class RegisterRequestDTO
    {
        public required String Username { get; set; }
        public required String Password { get; set; }
    }
}
