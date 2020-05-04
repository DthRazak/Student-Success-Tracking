using System;
using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using SST.Application.Common.Mapping;
using SST.Domain.Entities;

namespace SST.Application.Journal.Queries
{
    public class StudentDto : IMapFrom<Student>, IComparable<StudentDto>
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public int CompareTo([AllowNull] StudentDto other)
        {
            if (other == null)
            {
                return 1;
            }

            return FullName.CompareTo(other.FullName);
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Student, StudentDto>()
                .ForMember(x => x.FullName, y => y.MapFrom(z => z.LastName + " " + z.FirstName));
        }
    }
}
