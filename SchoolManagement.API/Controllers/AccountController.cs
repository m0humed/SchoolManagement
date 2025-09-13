using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Base;
using SchoolManagement.Core.Features.Users.Commands;

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
            catch
            {
                return BadRequest();
            }
        }

    }
}
