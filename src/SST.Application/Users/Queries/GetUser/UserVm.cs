using AutoMapper;
using SST.Application.Common.Mapping;
using SST.Domain.Entities;

namespace SST.Application.Users.Queries.GetUser
{
    public class UserVm : IMapFrom<User>
    {
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsApproved { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserVm>()
                .ForMember(x => x.IsApproved, y => y.MapFrom(z => z.Request.IsApproved));
        }
    }
}
