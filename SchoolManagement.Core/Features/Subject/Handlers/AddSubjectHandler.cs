using MediatR;
using Microsoft.Identity.Client;
using SchoolManagement.Core.Features.Subject.Commands;
using SchoolManagement.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Features.Subject.Handlers
{
    public class AddSubjectHandler : IRequestHandler<AddSubjectCommand>
    {
        #region Fields
        private readonly ISubjectService _subjectService;
        #endregion

        #region ctor
        public AddSubjectHandler(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        #endregion

        #region Methods
        public async Task Handle(AddSubjectCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            if (request.subject == null)
            { 
                throw new NullReferenceException(nameof(request.subject));
            }
            if (request.subject.Id == Guid.Empty)
            {
                request.subject.Id = Guid.NewGuid();
            }
            await _subjectService.AddAsync(request.subject);
        }
        #endregion

    }
}
