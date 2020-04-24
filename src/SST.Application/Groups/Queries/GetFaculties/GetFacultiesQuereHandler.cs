using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace SST.Application.Groups.Queries.GetFaculties
{
    public class GetFacultiesQueryHandler : IRequestHandler<GetFacultiesQuery, FacultyListVm>
    {
        public async Task<FacultyListVm> Handle(GetFacultiesQuery request, CancellationToken cancellationToken)
        {
            var faculties = new List<string>
            {
                "Факультет прикладної математики та інформатики",
                "Біологічний факультет",
                "Географічний факультет",
                "Геологічний факультет",
                "Економічний факультет",
                "Факультет електроніки та комп’ютерних технологій",
                "Факультет журналістики",
                "Факультет іноземних мов",
                "Історичний факультет",
                "Факультет культури і мистецтв",
                "Механіко-математичний факультет",
                "Факультет міжнародних відносин",
                "Факультет педагогічної освіти",
                "Факультет управління фінансами та бізнесу",
                "Фізичний факультет",
                "Філологічний факультет",
                "Філософський факультет",
                "Хімічний факультет",
                "Юридичний факультет",
            };

            return new FacultyListVm { Faculties = faculties };
        }
    }
}
