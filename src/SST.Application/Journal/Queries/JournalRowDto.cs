using System;
using System.Collections.Generic;

namespace SST.Application.Journal.Queries
{
    public class JournalRowDto
    {
        public JournalRowDto(IList<DateTime> dateTimes)
        {
            Row = new SortedList<DateTime, int>();
            foreach (var date in dateTimes)
            {
                Row.Add(date, 0);
            }
        }

        public SortedList<DateTime, int> Row { get; set; }

        public int Total { get; set; }
    }
}
