using System.Collections.Generic;

namespace SST.Domain.Entities
{
    public class Subject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int LectorRef { get; set; }

        public Lector Lector { get; set; }

        public ICollection<StudentSubject> StudentSubjects { get; private set; }
    }
}
