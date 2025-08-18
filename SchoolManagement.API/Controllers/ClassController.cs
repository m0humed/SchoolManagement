using MediatR;
using Microsoft.AspNetCore.Mvc;
using Schoolmanagement.Domain.Entities;
using SchoolManagement.API.Base;
using SchoolManagement.Core.Features.Class.Commands;
using SchoolManagement.Core.Features.Class.Queries;

namespace SchoolManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : AppController
    {
        #region Fields
        private readonly IMediator _mediator;

        #endregion

        #region Constructors
        public ClassController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        [Route("AddClass")]
        public async Task<IActionResult> CreateClass([FromBody] Class command)
        {
            if (command == null)
            {
                return BadRequest("Invalid class data.");
            }
            try
            {
                await _mediator.Send(new AddClassCommand(command));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }

            return Ok("Class added success");
        }

        [HttpGet]
        [Route("GetAllClasses")]
        public async Task<IActionResult> GetAllClasses()
        {
            try
            {
                // Assuming you have a query to get all classes
                var classes = await _mediator.Send(new GetAllClassesQuery());
                return Ok(classes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("UpdateClass")]
        public async Task<IActionResult> updateClass(EditClassCommand command)
        {
            var result = await _mediator.Send(command);
            return NewResult(result);
        }

        #endregion

    }
}
