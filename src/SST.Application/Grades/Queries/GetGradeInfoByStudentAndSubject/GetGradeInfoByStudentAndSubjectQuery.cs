using MediatR;

namespace SST.Application.Grades.Queries.GetGradeInfoByStudentAndSubject
{
    public class GetGradeInfoByStudentAndSubjectQuery : IRequest<GradesInfoVm>
    {
        public int StudentId { get; set; }

        public int SubjectId { get; set; }
    }
}
