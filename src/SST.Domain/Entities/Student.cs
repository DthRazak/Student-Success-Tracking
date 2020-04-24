using System.Collections.Generic;

namespace SST.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? GroupRef { get; set; }

        public string UserRef { get; set; }

        public Group Group { get; set; }

        public User User { get; set; }

        public ICollection<Grade> Grades { get; set; }

        public ICollection<SecondaryGroup> SecondaryGroups { get; set; }
    }
}
