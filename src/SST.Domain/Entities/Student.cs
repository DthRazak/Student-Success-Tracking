using System.Collections.Generic;

namespace SST.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Group { get; set; }

        public string UserRef { get; set; }

        public User User { get; set; }

        public ICollection<StudentSubject> StudentSubjects { get; private set; }
    }
}
