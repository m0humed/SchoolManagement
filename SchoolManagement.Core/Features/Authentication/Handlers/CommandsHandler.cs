using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Schoolmanagement.Domain.Entities.Identity;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Authentication.Commands;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Core.Features.Authentication.Handlers
{
    public class CommandsHandler : ResponseHandler, IRequestHandler<SignInCommand, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationService _authenticationService;
        #endregion
        public CommandsHandler(IStringLocalizer<SharedResources> localizer, SignInManager<User> signInManager
                               , UserManager<User> userManager
                               , IAuthenticationService authenticationService) : base(localizer)
        {
            _signInManager = signInManager;
            _localizer = localizer;
            _userManager = userManager;
            _authenticationService = authenticationService;
        }

        public async Task<Response<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                return NullRequest<string>();
            var user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);
            if (user == null)
            {
                user = await _userManager.FindByNameAsync(request.UsernameOrEmail);
                if (user == null)
                    return NotFound<string>(_localizer[SharedResourcesKeys.notFound]);
            }
            var SignCheck = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!SignCheck.Succeeded)
                return BadRequest<string>(_localizer[SharedResourcesKeys.FalsePassword]);

            var token = await _authenticationService.CreateJWTToken(user);

            return Success(token);
        }
    }
}
