using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schoolmanagement.Domain.Entities;
using SchoolManagement.Core.Features.Class.Commands;
using SchoolManagement.Core.Features.Class.Queries;

namespace SchoolManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IMediator _mediator;
        #region Fields

        #endregion

        #region Constructors
        public ClassController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        #endregion

        #region Actions
        [HttpPost]
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

        #endregion

    }
}
