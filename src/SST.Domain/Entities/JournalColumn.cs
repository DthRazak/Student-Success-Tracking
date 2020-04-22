using System;
using System.Collections.Generic;

namespace SST.Domain.Entities
{
    public class JournalColumn
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Note { get; set; }

        public int GroupSubjectRef { get; set; }

        public GroupSubject GroupSubject { get; set; }

        public ICollection<Grade> Grades { get; set; }
    }
}
