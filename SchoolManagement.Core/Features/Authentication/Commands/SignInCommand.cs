using MediatR;
using SchoolManagement.Core.Bases;


namespace SchoolManagement.Core.Features.Authentication.Commands
{
    public record SignInCommand : IRequest<Response<string>>
    {
        public string UsernameOrEmail { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
