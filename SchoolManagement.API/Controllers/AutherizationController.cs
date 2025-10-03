using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Base;
using SchoolManagement.Core.Features.Autherization.Commands;

namespace SchoolManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AutherizationController : AppController
    {

        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region Constructors
        public AutherizationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole([FromForm] AddRoleCommand command)
        {
            var result = await _mediator.Send(command);
            return NewResult(result);
        }
    }
}
