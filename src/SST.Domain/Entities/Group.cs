using System.Collections.Generic;

namespace SST.Domain.Entities
{
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Faculty { get; set; }

        public int Year { get; set; }

        public bool IsMain { get; set; }

        public ICollection<Student> Students { get; set; }

        public ICollection<SecondaryGroup> SecondaryGroups { get; set; }

        public ICollection<GroupSubject> GroupSubjects { get; set; }
    }
}
