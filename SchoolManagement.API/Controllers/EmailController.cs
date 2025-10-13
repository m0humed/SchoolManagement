using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Base;
using SchoolManagement.Core.Features.Mail.Commands;

namespace SchoolManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : AppController
    {

        #region Fileds
        private IMediator _mediator;
        #endregion
        #region Constructirs
        public EmailController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Controllers
        [HttpPost("SendEmail")]
        public async Task<IActionResult> SendEmail([FromBody] SendEmailCommand command)
        {
            var result = await _mediator.Send(command);
            return NewResult(result);
        }
        #endregion



    }
}
