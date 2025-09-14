using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Base;
using SchoolManagement.Core.Features.Users.Commands;
using SchoolManagement.Core.Features.Users.Queries;

namespace SchoolManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : AppController
    {
        #region Fields
        //private UserManager<User> _userManager;
        private IMediator _mediator;
        #endregion

        public AccountController(IMediator mediator)
        {
            //_userManager = userManager;
            _mediator = mediator;
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] AddUserCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                return NewResult(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPageUser")]
        public async Task<IActionResult> GetPageUser([FromQuery] GetPaginatedUsersQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetuserById")]
        public async Task<IActionResult> GetUser([FromQuery] GetUserByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return NewResult(result);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                return NewResult(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DeleteUser/{id}")]
        public async Task<IActionResult> UpdateUser(string id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteUserCommand { id = id });

                return NewResult(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword([FromBody] ChangePasswordCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                return NewResult(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
