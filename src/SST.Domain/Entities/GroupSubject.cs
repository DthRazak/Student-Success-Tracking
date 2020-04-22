using System.Collections.Generic;

namespace SST.Domain.Entities
{
    public class GroupSubject
    {
        public int Id { get; set; }

        public int GroupRef { get; set; }

        public int SubjectRef { get; set; }

        public Group Group { get; set; }

        public Subject Subject { get; set; }

        public ICollection<JournalColumn> Journal { get; set; }
    }
}
