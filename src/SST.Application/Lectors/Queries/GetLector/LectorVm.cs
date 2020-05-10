using AutoMapper;
using SST.Application.Common.Mapping;
using SST.Domain.Entities;

namespace SST.Application.Lectors.Queries.GetLector
{
    public class LectorVm : IMapFrom<Lector>
    {
        public string FullName { get; set; }

        public string AcademicStatus { get; set; }

        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Lector, LectorVm>()
                  .ForMember(x => x.Email, y => y.MapFrom(z => z.UserRef))
                  .ForMember(x => x.FullName, y => y.MapFrom(z => z.LastName + " " + z.FirstName));
        }
    }
}
