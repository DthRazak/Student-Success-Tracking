﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SST.Application.Subjects.Queries.GetSubjectsByStudent
{
    public class GetSubjectsByStudentQueryHandler : IRequestHandler<GetSubjectsByStudentQuery, SubjectsListVm>
    {
        private readonly ISSTDbContext _context;
        private readonly IMapper _mapper;

        public GetSubjectsByStudentQueryHandler(ISSTDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SubjectsListVm> Handle(GetSubjectsByStudentQuery request, CancellationToken cancellationToken)
        {
            var subjects = await _context.StudentSubjects
               .Where(x => x.StudentRef == request.StudentId)
               .ProjectTo<SubjectDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);

            return new SubjectsListVm { Subjects = subjects };
        }
    }
}