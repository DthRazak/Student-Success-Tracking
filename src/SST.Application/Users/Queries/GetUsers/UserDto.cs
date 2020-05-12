using AutoMapper;
using SST.Application.Common.Mapping;
using SST.Domain.Entities;

namespace SST.Application.Users.Queries.GetUsers
{
    public class UserDto : IMapFrom<User>
    {
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsApproved { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDto>()
                .ForMember(x => x.IsApproved, y => y.MapFrom(z => z.Request.IsApproved));
        }
    }
}
