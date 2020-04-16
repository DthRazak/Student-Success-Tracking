
namespace SST.Domain.Entities
{
    public class Grade
    {
        public int Id { get; set; }

        public int Mark { get; set; }

        public int StudentSubjectRef { get; set; }

        public StudentSubject StudentSubject { get; set; }

        public System.DateTime Date { get; set; }
    }
}
