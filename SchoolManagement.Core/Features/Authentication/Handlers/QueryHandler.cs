using MediatR;
using Microsoft.Extensions.Localization;
using Schoolmanagement.Domain.Enums;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Authentication.Queries;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.IServices;
namespace SchoolManagement.Core.Features.Authentication.Handlers
{
    public class QueryHandler : ResponseHandler, IRequestHandler<ValidateTokenQuery, Response<string>>
                                               , IRequestHandler<VerifyEmailQuery, Response<bool>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IAuthenticationService _authentication;
        private readonly IApplicationUserService _applicationUserService;
        private readonly IUserService _userService;
        #endregion

        #region Constructors
        public QueryHandler(IStringLocalizer<SharedResources> localizer, IAuthenticationService authentication, IApplicationUserService applicationUserService, IUserService userService) : base(localizer)
        {
            _localizer = localizer;
            _authentication = authentication;
            _applicationUserService = applicationUserService;
            _userService = userService;
        }
        #endregion

        #region Handlers
        public async Task<Response<string>> Handle(ValidateTokenQuery request, CancellationToken cancellationToken)
        {
            var result = await _authentication.ValidateToken(request.AccessToken);
            if (result.Equals("NotExpired"))
                return Success(result);
            return BadRequest<string>("Expired");

        }

        public async Task<Response<bool>> Handle(VerifyEmailQuery request, CancellationToken cancellationToken)
        {

            var result = await _applicationUserService.VerifyConfermationUrlAsync(request.UserId, request.Code);
            switch (result.ServiceError)
            {
                case ServiceErrorEnum.None:
                    return Success(true);
                case ServiceErrorEnum.NotValidUserId:
                    return BadRequest<bool>(result.Message);
                default:
                    return BadRequest<bool>(result.Message);
            }
        }
        #endregion
    }
}
