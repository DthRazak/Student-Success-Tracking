using MediatR;

namespace SST.Application.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserVm>
    {
        public string Email { get; set; }
    }
}
