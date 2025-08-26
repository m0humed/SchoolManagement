using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Teachers.Queries;
using SchoolManagement.Core.Features.Teachers.Results;
using SchoolManagement.Core.Resources;
using SchoolManagement.Core.Wrappers;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Core.Features.Teachers.Handlers
{
    public class GetTeachersPaginateHandler : ResponseHandler, IRequestHandler<GetTeachersPaginateQuery, PaginationResult<GetTeachersPaginateResult>>
    {
        #region Fields
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion
        #region construcors
        public GetTeachersPaginateHandler(ITeacherService teacherService, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _mapper = mapper;
            _teacherService = teacherService;
            _localizer = localizer;
        }
        #endregion
        public async Task<PaginationResult<GetTeachersPaginateResult>> Handle(GetTeachersPaginateQuery request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var Result = _teacherService.GetAllQuerable();

            if (Result == null) throw new ArgumentNullException("null");

            if (request.Search != null)
            {
                Result = _teacherService.FilterSearchinQuerable(request.Search);
            }
            if (request.OrderBy != null)
            {
                Result = _teacherService.OrderTeachers(request.OrderBy, Result);
            }


            var mappedResult = _mapper.Map<List<GetTeachersPaginateResult>>(Result);

            var Pagenated = await mappedResult.AsQueryable().PaginationExtinsionAsync(request.PageNumber, request.PageSize);

            return Pagenated;
        }
    }
}
