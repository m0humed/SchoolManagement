using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Authentication.Queries;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Core.Features.Authentication.Handlers
{
    public class QueryHandler : ResponseHandler, IRequestHandler<ValidateTokenQuery, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IAuthenticationService _authentication;
        #endregion
        public QueryHandler(IStringLocalizer<SharedResources> localizer, IAuthenticationService authentication) : base(localizer)
        {
            _localizer = localizer;
            _authentication = authentication;
        }

        public async Task<Response<string>> Handle(ValidateTokenQuery request, CancellationToken cancellationToken)
        {
            var result = await _authentication.ValidateToken(request.AccessToken);
            if (result.Equals("NotExpired"))
                return Success(result);
            return BadRequest<string>("Expired");

        }
    }
}
