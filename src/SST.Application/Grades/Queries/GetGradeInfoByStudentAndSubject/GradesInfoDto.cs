using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SST.Application.Common.Extensions;
using SST.Application.Common.Mapping;
using SST.Domain.Entities;

namespace SST.Application.Grades.Queries.GetGradeInfoByStudentAndSubject
{
    public class GradesInfoDto : IMapFrom<StudentSubject>
    {
        public string StudentFullName { get; set; }

        public SortedList<DateTime, int> Marks { get; set; }

        public int Total { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StudentSubject, GradesInfoDto>()
                .ForMember(x => x.StudentFullName, y => y.MapFrom(z => z.Student.FirstName + " " + z.Student.LastName))
                .ForMember(x => x.Total, y => y.MapFrom(z => z.Grades.Select(g => g.Mark).Sum()))
                .ForMember(x => x.Marks, y => y.MapFrom(z => z.Grades.ToSortedList(g => g.Date, g => g.Mark)));
        }
    }
}
