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

    public class GetAllSubjectsHandler : IRequestHandler<GetAllSubjectsQuery, IEnumerable<Subject>>
    {

        #region Fields
        private readonly ISubjectService _subjectService;
        #endregion

        #region ctor
        public GetAllSubjectsHandler(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        #endregion

        #region Methods
        public async Task<IEnumerable<Subject>> Handle(GetAllSubjectsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            return await _subjectService.GetAllAsync();
        }

        #endregion

    }
}
