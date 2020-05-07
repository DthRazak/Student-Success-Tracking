using MediatR;

namespace SST.Application.Lectors.Commands.CreateOrUpdateGradeByLector
{
    public class CreateOrUpdateGradeByLectorCommand : IRequest<int>
    {
        public int GradeId { get; set; }

        public int Mark { get; set; }

        public int StudentId { get; set; }

        public int JournalColumnId { get; set; }

        public int LectorId { get; set; }
    }
}
