namespace SST.Domain.Entities
{
    public class SecondaryGroup
    {
        public int Id { get; set; }

        public int StudentRef { get; set; }

        public int GroupRef { get; set; }

        public Student Student { get; set; }

        public Group Group { get; set; }
    }
}
