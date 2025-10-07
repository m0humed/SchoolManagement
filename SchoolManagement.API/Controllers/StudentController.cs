using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SchoolManagement.API.Base;
using SchoolManagement.Core.Features.Student.Commands;
using SchoolManagement.Core.Features.Student.Queries;
using SchoolManagement.Core.Features.Student.Results;
using SchoolManagement.Core.Resources;

namespace SchoolManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class StudentController : AppController
    {
        #region fields
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<SharedResources> _localization;
        #endregion

        #region Consturctors
        public StudentController(IMediator mediator, IStringLocalizer<SharedResources> localization)
        {
            _mediator = mediator;
            _localization = localization;
        }
        #endregion
        #region Actions

        [HttpPost("AddStudent")]
        //[Authorize(Policy = "Create Student")]
        public async Task<IActionResult> addStudent([FromBody] AddStudentCommand command)
        {
            if (command == null)
                return NewResult<bool>(
                    new Core.Bases.Response<bool>
                    {
                        Data = false,
                        StatusCode = System.Net.HttpStatusCode.BadRequest,
                        Message = _localization[SharedResourcesKeys.StudentDataNotValid],
                        Succeeded = false
                    }
                    );

            try
            {
                var Result = await _mediator.Send(command);
                return NewResult(Result);
            }
            catch
            {
                return NewResult<bool>(
                    new Core.Bases.Response<bool>
                    {
                        Data = false,
                        StatusCode = System.Net.HttpStatusCode.InternalServerError,
                        Message = _localization[SharedResourcesKeys.error],
                        Succeeded = false
                    }
                    );
            }

        }

        [HttpGet("GetAllStudents")]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var result = await _mediator.Send(new GetAllStudentsQuery());
                return NewResult(result);
            }
            catch
            {
                return NewResult(
                    new Core.Bases.Response<IEnumerable<GetStudentDataResult>>
                    {
                        Data = [],
                        StatusCode = System.Net.HttpStatusCode.InternalServerError,
                        Message = _localization[SharedResourcesKeys.RetriveStudentError],
                        Succeeded = false
                    }
                    );
            }

        }

        [HttpGet("GetStudent/{Id}")]
        public async Task<IActionResult> GetStudent(string Id)
        {
            try
            {
                var result = await _mediator.Send(new GetStudentByIdQuery { Id = Id });
                return NewResult(result);
            }
            catch
            {
                return NewResult(
                    new Core.Bases.Response<GetStudentDataResult>
                    {
                        Data = new GetStudentDataResult(),
                        StatusCode = System.Net.HttpStatusCode.InternalServerError,
                        Message = _localization[SharedResourcesKeys.RetriveStudentError],
                        Succeeded = false
                    }
                    );
            }
        }
        #endregion


    }
}
