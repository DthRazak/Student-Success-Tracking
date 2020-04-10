using AutoMapper;
using SST.Application.Common.Mapping;
using SST.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SST.Application.Grades.Queries.GetGradeInfoByGroupAndSubject
{
    public class GradesInfoDto : IMapFrom<StudentSubject>
    {
        public string StudentFullName { get; set; }

        public List<int> Marks { get; set; }

        public int Total { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StudentSubject, GradesInfoDto>()
                .ForMember(x => x.StudentFullName, y => y.MapFrom(z => z.Student.FirstName + " " + z.Student.LastName))
                .ForMember(x => x.Marks, y => y.MapFrom(z => (from grade in z.Grades select grade.Mark).ToList()))
                .ForMember(x => x.Total, y => y.MapFrom(z => (from grade in z.Grades select grade.Mark).Sum()));
        }
    }
}
