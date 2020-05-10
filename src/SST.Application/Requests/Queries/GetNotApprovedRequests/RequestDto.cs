using System;
using AutoMapper;
using SST.Application.Common.Mapping;
using SST.Domain.Entities;

namespace SST.Application.Requests.Queries.GetNotApprovedRequests
{
    public class RequestDto : IMapFrom<Request>
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public DateTime CreationDate { get; set; }

        public string Type { get; set; }

        public string UserRef { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Request, RequestDto>()
                .ForMember(x => x.Type, y => y.MapFrom(z => z.User.Lector != null ? "Lector" : "Student"))
                .ForMember(x => x.FullName, y => y.MapFrom(z =>
                    (z.User.Lector != null) ?
                        z.User.Lector.LastName + " " + z.User.Lector.FirstName
                    :
                        z.User.Student.LastName + " " + z.User.Student.FirstName
                    ));
        }
    }
}
