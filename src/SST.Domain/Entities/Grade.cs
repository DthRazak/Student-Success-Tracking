namespace SST.Domain.Entities
{
    public class Grade
    {
        public int Id { get; set; }

        public int Mark { get; set; }

        public int StudentRef { get; set; }

        public int JournalColumnRef { get; set; }

        public Student Student { get; set; }

        public JournalColumn JournalColumn { get; set; }
    }
}
