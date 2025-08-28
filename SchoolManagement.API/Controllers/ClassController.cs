using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Schoolmanagement.Domain.Entities;
using SchoolManagement.API.Base;
using SchoolManagement.Core.Features.Class.Commands;
using SchoolManagement.Core.Features.Class.Queries;
using SchoolManagement.Core.Resources;

namespace SchoolManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : AppController
    {
        #region Fields
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<SharedResources> _localization;

        #endregion

        #region Constructors
        public ClassController(IMediator mediator, IStringLocalizer<SharedResources> localization)
        {
            this._mediator = mediator;
            _localization = localization;
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
                var result = await _mediator.Send(new AddClassCommand(command));
                return NewResult(result);
            }
            catch
            {
                return NewResult(new Core.Bases.Response<bool>
                {
                    Data = false,
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = _localization[SharedResourcesKeys.repetedClassNumber],
                    Succeeded = false
                });
            }
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

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> DeleteClass([FromRoute] string Id)
        {
            var result = await _mediator.Send(new DeleteClassCommand { Id = Guid.Parse(Id) });

            return NewResult(result);
        }
        #endregion

    }
}
