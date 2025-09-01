using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SchoolManagement.API.Base;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.ClassSchadual.Commands;
using SchoolManagement.Core.Resources;

namespace SchoolManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassSchadualController : AppController
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IMediator _mediator;

        #endregion

        #region Constructors
        public ClassSchadualController(IMapper mapper, IStringLocalizer<SharedResources> localizer, IMediator mediator)
        {
            _mapper = mapper;
            _localizer = localizer;
            _mediator = mediator;
        }
        #endregion

        [HttpPost("AddClassSchadual")]
        public async Task<IActionResult> AddSchadual([FromBody] AddClassSchadualCommand command)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(command);
                return NewResult(result);
            }
            else
            {
                return NewResult<bool>
                    (
                        new Response<bool>
                        {
                            Data = false,
                            StatusCode = System.Net.HttpStatusCode.BadRequest,
                            Message = _localizer[SharedResourcesKeys.NotValidRequest],
                            Succeeded = false
                        }

                    );
            }

        }

    }
}
