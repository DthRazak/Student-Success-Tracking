using MediatR;

namespace SST.Application.Students.Commands.UnlinkStudent
{
    public class UnlinkStudentCommand : IRequest
    {
        public int Id { get; set; }
    }
}
