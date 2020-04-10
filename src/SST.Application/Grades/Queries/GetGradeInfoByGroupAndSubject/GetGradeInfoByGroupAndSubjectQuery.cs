using MediatR;

namespace SST.Application.Grades.Queries.GetGradeInfoByGroupAndSubject
{
    public class GetGradeInfoByGroupAndSubjectQuery : IRequest<GradesInfoListVm>
    {
        public string Group { get; set; }

        public int SubjectId { get; set; }
    }
}
