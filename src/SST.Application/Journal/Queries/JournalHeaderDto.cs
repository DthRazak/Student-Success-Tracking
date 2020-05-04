using System;
using System.Diagnostics.CodeAnalysis;

namespace SST.Application.Journal.Queries
{
    public class JournalHeaderDto : IComparable<JournalHeaderDto>
    {
        public int ColumnId { get; set; }

        public DateTime Date { get; set; }

        public string Note { get; set; }

        public int CompareTo([AllowNull] JournalHeaderDto other)
        {
            if (other == null)
            {
                return 1;
            }

            return Date.CompareTo(other.Date);
        }
    }
}
