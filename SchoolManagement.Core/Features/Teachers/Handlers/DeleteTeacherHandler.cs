using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Teachers.Commands;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Core.Features.Teachers.Handlers
{
    public class DeleteTeacherHandler : ResponseHandler, IRequestHandler<DeleteTeacherCommand, Response<string>>
    {
        #region Fields
        private readonly ITeacherService _service;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion
        #region constructors
        public DeleteTeacherHandler(ITeacherService service, IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _service = service;
            _localizer = localizer;
        }
        #endregion
        public async Task<Response<string>> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            if (request == null) return BadRequest<string>("must contain ID ");
            try
            {
                await _service.DeleteAsync(request.ssn);
                return Deleted<string>();
            }
            catch (Exception ex)
            {
                return BadRequest<string>(ex.Message);
            }
        }
    }
}
