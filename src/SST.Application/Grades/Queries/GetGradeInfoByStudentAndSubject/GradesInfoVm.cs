using System;
using System.Collections.Generic;

namespace SST.Application.Grades.Queries.GetGradeInfoByStudentAndSubject
{
    public class GradesInfoVm
    {
        public string StudentFullName { get; set; }

        public IList<DateTime> Dates { get; set; }

        public IList<GradesInfoDto> GradesInfos { get; set; }
    }
}
