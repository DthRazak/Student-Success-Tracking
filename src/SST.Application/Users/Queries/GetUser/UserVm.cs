using AutoMapper;
using SST.Application.Common.Mapping;
using SST.Domain.Entities;

namespace SST.Application.Users.Queries.GetUser
{
    public class UserVm : IMapFrom<User>
    {
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string Role { get; set; }

        public bool? IsApproved { get; set; }

        public int SSTID { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserVm>()
                .ForMember(x => x.IsApproved, y => y.MapFrom(z => z.Request.IsApproved))
                .ForMember(x => x.Role, y => y.MapFrom(z => z.IsAdmin ? "Admin" : z.Lector != null ? "Lector" : "Student"))
                .ForMember(x => x.SSTID, y => y.MapFrom(z =>
                    (!z.IsAdmin && z.Lector != null) ?
                        z.Lector.Id
                    : (!z.IsAdmin && z.Student != null) ?
                        z.Student.Id
                    : 0));
        }
    }
}
