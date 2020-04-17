using AutoMapper;
using SST.Application.Common.Mapping;
using SST.Domain.Entities;

namespace SST.Application.Students.Queries.GetStudent
{
    public class StudentVm : IMapFrom<Student>
    {
        public string FullName { get; set; }

        public string Group { get; set; }

        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Student, StudentVm>()
                  .ForMember(x => x.Email, y => y.MapFrom(z => z.UserRef))
                  .ForMember(x => x.FullName, y => y.MapFrom(z => z.FirstName + " " + z.LastName));
        }
    }
}
