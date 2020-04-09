﻿using AutoMapper;
using SST.Application.Common.Mapping;
using SST.Domain.Entities;

namespace SST.Application.Subjects.Queries
{
    public class SubjectDto : IMapFrom<Subject>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LectorFullName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Subject, SubjectDto>()
                .ForMember(x => x.LectorFullName, y => y.MapFrom(z => z.Lector.FirstName + " " + z.Lector.LastName));
            profile.CreateMap<StudentSubject, SubjectDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Subject.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Subject.Name))
                .ForMember(x => LectorFullName, y => y.MapFrom(z => z.Subject.Lector.FirstName + " " + z.Subject.Lector.LastName));
        }
    }
}
