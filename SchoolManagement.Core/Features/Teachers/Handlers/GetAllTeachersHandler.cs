using MediatR;
using Microsoft.Extensions.Localization;
using Schoolmanagement.Domain.Entities;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Teachers.Queries;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Core.Features.Teachers.Handlers
{
    public class GetAllTeachersHandler : ResponseHandler, IRequestHandler<GetAllTeachersQuery, Response<IEnumerable<Teacher>>>
    {
        private ITeacherService _service;
        private readonly IStringLocalizer<SharedResources> _localizer;


        public GetAllTeachersHandler(ITeacherService teacherService, IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _service = teacherService;
            _localizer = localizer;
        }
        public async Task<Response<IEnumerable<Teacher>>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
        {
            return Success(await _service.GetAllAsync());

        }
    }
}
