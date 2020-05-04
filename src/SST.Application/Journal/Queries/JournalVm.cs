using System.Collections.Generic;

namespace SST.Application.Journal.Queries
{
    public class JournalVm
    {
        public string StudentFullName { get; set; }

        public int JournalId { get; set; }

        public IList<JournalHeaderDto> Header { get; set; }

        public SortedList<StudentDto, JournalRowDto> Journal { get; set; }
    }
}
