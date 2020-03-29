using MediatR;

namespace SST.Application.Users.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<UsersListVm>
    {
    }
}
