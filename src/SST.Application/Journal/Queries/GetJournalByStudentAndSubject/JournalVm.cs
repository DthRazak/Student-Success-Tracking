using System.Collections.Generic;

namespace SST.Application.Journal.Queries.GetJournalByStudentAndSubject
{
    public class JournalVm
    {
        public string StudentFullName { get; set; }

        public IList<JournalColumnDto> Journal { get; set; }

        public SortedList<string, int> Total { get; set; }
    }
}
