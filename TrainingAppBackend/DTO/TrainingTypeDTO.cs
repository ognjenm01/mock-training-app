namespace TrainingAppBackend.DTO
{
    public class TrainingTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TrainingTypeDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
