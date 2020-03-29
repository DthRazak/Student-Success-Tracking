using AutoMapper;
using SST.Application.Common.Mapping;
using SST.Domain.Entities;

namespace SST.Application.Lectors.Queries.GetLectors
{
    public class LectorDto : IMapFrom<Lector>
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public string AcademicStatus { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Lector, LectorDto>()
                .ForMember(x => x.FullName, y => y.MapFrom(z => z.FirstName + " " + z.LastName));
        }
    }
}
