using MediatR;
using SchoolManagement.Core.Features.Subject.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Features.Subject.Handlers
{
    using Schoolmanagement.Domain.Entities;
    using SchoolManagement.Service.IServices;
    using System.Threading;

    public class GetSubjectByIdHandler : IRequestHandler<GetSubjectByIdQuery, Subject>
    {

        #region Fields
        private readonly ISubjectService _subjectService;
        #endregion

        #region ctor
        public GetSubjectByIdHandler(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        #endregion

        #region 
        public async Task<Subject> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            if (request.subjectId == Guid.Empty)
            {
                throw new Exception($"no Subject with this Id {request.subjectId}");
            }

            return await _subjectService.GetByIdAsync(request.subjectId);

        }
        #endregion

    }
}
