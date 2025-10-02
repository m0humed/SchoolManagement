using MediatR;
using Schoolmanagement.Domain.Results;
using SchoolManagement.Core.Bases;


namespace SchoolManagement.Core.Features.Authentication.Commands
{
    public record SignInCommand : IRequest<Response<JwtAuthenticationResult>>
    {
        public string UsernameOrEmail { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
