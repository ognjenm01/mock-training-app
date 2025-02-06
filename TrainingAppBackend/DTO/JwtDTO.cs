namespace TrainingAppBackend.DTO
{
    public class JwtDTO
    {
        public String token {  get; set; }

        public JwtDTO(String token)
        {
            this.token = token;
        }
    }
}
