using MediatR;
using Schoolmanagement.Domain.Results;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.Authentication.Commands
{
    public class RefreshTokenCommand : IRequest<Response<JwtAuthenticationResult>>
    {
        public string AccessToken { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
    }
}
