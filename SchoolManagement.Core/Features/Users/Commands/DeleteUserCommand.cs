using MediatR;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.Users.Commands
{
    public record DeleteUserCommand : IRequest<Response<bool>>
    {
        public string id { get; set; } = null!;
    }
}
