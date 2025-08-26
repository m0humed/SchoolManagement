using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Teachers.Queries;

namespace SchoolManagement.Core.Features.Teachers.Handlers
{
    using Microsoft.Extensions.Localization;
    using Schoolmanagement.Domain.Entities;
    using SchoolManagement.Core.Resources;
    using SchoolManagement.Service.IServices;
    using System.Threading;

    public class GetTeacherByIdHandler : ResponseHandler, IRequestHandler<GetTeacherByIdQuery, Response<Teacher>>
    {
        private readonly ITeacherService _teacherService;
        private readonly IStringLocalizer<SharedResources> _localizer;
        public GetTeacherByIdHandler(ITeacherService teacherService, IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _teacherService = teacherService;
            _localizer = localizer;
        }
        public async Task<Response<Teacher>> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return NullRequest<Teacher>(_localizer[SharedResourcesKeys.nullValue]);
            }

            if (request.ssn == null)
            {
                return NullRequest<Teacher>(_localizer[SharedResourcesKeys.nullValue]);
            }
            try
            {
                var teacher = await _teacherService.GetByIdAsync(request.ssn);
                if (teacher == null)
                    return NotFound<Teacher>(_localizer[SharedResourcesKeys.notFound]);
                return Success<Teacher>(teacher);
            }
            catch
            {
                return NotFound<Teacher>(_localizer[SharedResourcesKeys.notFound]);
            }

        }
    }
}
