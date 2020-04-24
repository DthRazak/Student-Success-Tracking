using System.Collections.Generic;
using SST.Application.Common.Mapping;
using SST.Domain.Entities;

namespace SST.Application.Subjects.Queries.GetSubjectsByLector
{
    public class SubjectDto : IMapFrom<Subject>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public SortedList<string, int> Groups { get; set; } = new SortedList<string, int>();
    }
}
