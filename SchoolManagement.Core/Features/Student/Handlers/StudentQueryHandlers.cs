using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Student.Queries;
using SchoolManagement.Core.Features.Student.Results;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Core.Features.Student.Handlers
{
    public class StudentQueryHandlers : ResponseHandler, IRequestHandler<GetAllStudentsQuery, Response<IEnumerable<GetStudentDataResult>>>
                                                       , IRequestHandler<GetStudentByIdQuery, Response<GetStudentDataResult>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors

        public StudentQueryHandlers(IStringLocalizer<SharedResources> localizer, IStudentService studentService, IMapper mapper) : base(localizer)
        {
            _localizer = localizer;
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion

        #region Handlers

        public async Task<Response<IEnumerable<GetStudentDataResult>>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _studentService.GetAllAsync();
                var MappedResult = _mapper.Map<IEnumerable<GetStudentDataResult>>(result);
                return Success(MappedResult);
            }
            catch
            {
                return ServerError<IEnumerable<GetStudentDataResult>>(_localizer[SharedResourcesKeys.RetriveStudentError]);
            }
        }

        public async Task<Response<GetStudentDataResult>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {

            if (request == null)
                return NullRequest<GetStudentDataResult>();
            if (request.Id == null || request.Id.Equals(string.Empty))
                return NullRequest<GetStudentDataResult>();
            try
            {
                var student = await _studentService.GetByIdAsync(request.Id);
                var mappedStudent = _mapper.Map<GetStudentDataResult>(student);
                return Success(mappedStudent);
            }
            catch
            {
                return NullRequest<GetStudentDataResult>();
            }

        }

        #endregion
    }
}
