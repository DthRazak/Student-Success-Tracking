using System;
using System.Collections.Generic;
using AutoMapper;
using SST.Application.Common.Extensions;
using SST.Application.Common.Mapping;
using SST.Domain.Entities;

namespace SST.Application.Journal.Queries
{
    public class JournalColumnDto : IMapFrom<JournalColumn>
    {
        public DateTime Date { get; set; }

        public string Note { get; set; }

        public SortedList<string, int> Grades { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<JournalColumn, JournalColumnDto>()
                .ForMember(x => x.Grades, y => y.MapFrom(z => z.Grades.ToSortedList(
                    g => g.Student.FirstName + " " + g.Student.LastName, g => g.Mark)));
        }
    }
}
