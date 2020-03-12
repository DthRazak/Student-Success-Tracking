using SST.Application.Common.Mapping;
using SST.Domain.Entities;

namespace SST.Application.Users.Queries.GetUser
{
    public class UserVm : IMapFrom<User>
    {
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public bool IsAdmin { get; set; }
    }
}
