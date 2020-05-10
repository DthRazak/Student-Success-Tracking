using System;
using System.Collections.Generic;

namespace SST.Application.Journal.Queries
{
    public class JournalRowDto
    {
        public JournalRowDto(IList<DateTime> dateTimes)
        {
            Row = new SortedList<DateTime, Tuple<int, int>>();
            foreach (var date in dateTimes)
            {
                Row.Add(date, new Tuple<int, int>(0, 0));
            }
        }

        public SortedList<DateTime, Tuple<int, int>> Row { get; set; }

        public int Total { get; set; }
    }
}
