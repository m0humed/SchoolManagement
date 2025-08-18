using MediatR;
using Microsoft.AspNetCore.Mvc;
using Schoolmanagement.Domain.Entities;
using SchoolManagement.API.Base;
using SchoolManagement.Core.Features.Teachers.Commands;
using SchoolManagement.Core.Features.Teachers.Queries;

namespace SchoolManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : AppController
    {
        #region Fields
        private IMediator _mediator;
        #endregion

        #region Constructors
        public TeachersController(IMediator mediator)
        {
            _mediator = mediator;

        }

        #endregion

        [HttpPost]
        [Route("AddTeacher")]
        public async Task<IActionResult> AddTeacher([FromBody] Teacher teacher)
        {
            if (teacher == null) return BadRequest("Null object");
            try
            {
                await _mediator.Send(new AddTeacherCommand(teacher));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpGet]
        [Route("GetAllTeachers")]
        public async Task<IActionResult> GetAllteachers()
        {

            var teachers = await _mediator.Send(new GetAllTeachersQuery());
            return NewResult(teachers);
        }

        [HttpGet("GetBySSN/{ssn}")]
        public async Task<IActionResult> GetBySSN(string ssn)
        {
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteTeacher([FromRoute] string id)
        {
            var result = await _mediator.Send(new DeleteTeacherCommand { ssn = id });
            return NewResult(result);
        }

        [HttpGet("Pagenated")]
        public async Task<IActionResult> pagenatedlist([FromQuery] GetTeachersPaginateQuery query)
        {
            if (query == null) return BadRequest();

            var result = await Mediator.Send(query);
            return Ok(result);

        }

    }
}
