using AutoMapper;
using SST.Application.Common.Mapping;
using SST.Domain.Entities;

namespace SST.Application.Students.Queries.GetStudents
{
    public class StudentDto : IMapFrom<Student>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Group { get; set; }

        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Student, StudentDto>()
                  .ForMember(x => x.Email, y => y.MapFrom(z => z.UserRef))
                  .ForMember(x => x.Group, y => y.MapFrom(z => z.Group.Name));
        }
    }
}
