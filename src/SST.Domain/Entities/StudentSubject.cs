using System.Collections.Generic;

namespace SST.Domain.Entities
{
    public class StudentSubject
    {
        public int Id { get; set; }

        public int StudentRef { get; set; }

        public int SubjectRef { get; set; }

        public Student Student { get; set; }

        public Subject Subject { get; set; }

        public ICollection<Grade> Grades { get; private set; }
    }
}
