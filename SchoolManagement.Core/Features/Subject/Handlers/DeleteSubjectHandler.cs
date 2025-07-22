using MediatR;
using SchoolManagement.Core.Features.Subject.Commands;
using SchoolManagement.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Features.Subject.Handlers
{
    public class DeleteSubjectHandler : IRequestHandler<DeleteSubjectCommand>
    {

        #region Fields
        private readonly ISubjectService _subjectService;
        #endregion

        #region ctor
        public DeleteSubjectHandler(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        #endregion
        #region Methods
        public async Task Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            if (request.subjectId == Guid.Empty)
            {
                throw new Exception($"No subject with this Id {request.subjectId}");
            }
            await _subjectService.DeleteAsync(request.subjectId);
        }
        #endregion

        

    }
}
