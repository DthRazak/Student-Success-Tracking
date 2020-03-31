using AutoMapper;
using SST.Application.Common.Mapping;
using SST.Domain.Entities;

namespace SST.Application.Lectors.Queries.GetLectors
{
    public class LectorDto : IMapFrom<Lector>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AcademicStatus { get; set; }

        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Lector, LectorDto>()
                  .ForMember(x => x.Email, y => y.MapFrom(z => z.UserRef));
        }
    }
}
