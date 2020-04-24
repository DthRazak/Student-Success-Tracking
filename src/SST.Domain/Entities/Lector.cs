using System.Collections.Generic;

namespace SST.Domain.Entities
{
    public class Lector
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AcademicStatus { get; set; }

        public string UserRef { get; set; }

        public User User { get; set; }

        public ICollection<Subject> Subjects { get; private set; }
    }
}
