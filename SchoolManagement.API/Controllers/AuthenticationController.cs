using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Base;
using SchoolManagement.Core.Features.Authentication.Commands;
using SchoolManagement.Core.Features.Authentication.Queries;

namespace SchoolManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : AppController
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region Constructors
        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion
        #region Actions
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromForm] SignInCommand command)
        {
            var tokent = await _mediator.Send(command);

            return NewResult(tokent);
        }
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromForm] RefreshTokenCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpGet("Validate")]
        public async Task<IActionResult> ValidateToken([FromQuery] ValidateTokenQuery command)
        {
            var tokent = await _mediator.Send(command);

            return NewResult(tokent);
        }

        [HttpGet("VerifyEmail")]
        public async Task<IActionResult> VerifyEmail([FromQuery] VerifyEmailQuery command)
        {
            var tokent = await _mediator.Send(command);

            return NewResult(tokent);
        }

        #endregion

    }
}
