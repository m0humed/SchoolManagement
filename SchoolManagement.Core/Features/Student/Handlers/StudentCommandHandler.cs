using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Student.Commands;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Core.Features.Student.Handlers
{
    using Schoolmanagement.Domain.Entities;
    public class StudentCommandHandler : ResponseHandler, IRequestHandler<AddStudentCommand, Response<bool>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public StudentCommandHandler(IStringLocalizer<SharedResources> localizer, IStudentService studentService, IMapper mapper) : base(localizer)
        {
            _localizer = localizer;
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion

        #region Handlers
        public async Task<Response<bool>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return NullRequest<bool>();
            }
            try
            {
                var Student = _mapper.Map<Student>(request);
                if (Student == null)
                {
                    return NullRequest<bool>();
                }

                //if (Student.Id == null)
                {
                    string year = DateTime.Now.Year.ToString().Substring(2);
                    string centryCode = DateTime.Now.Year.ToString().Substring(1, 1);
                    string randomPart = new Random().Next(1000, 9999).ToString();
                    Student.Id = $"{year}{centryCode}{randomPart}";
                }
                await _studentService.AddAsync(Student);
                return Created<bool>(true);
            }
            catch
            {
                return BadRequest<bool>();
            }

        }

        #endregion
    }
}
