using MediatR;
using Schoolmanagement.Domain.Enums;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.Users.Commands
{
    public record UpdateUserCommand : IRequest<Response<bool>>
    {

        public Guid Id { get; set; }
        public string ssn { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public Gender Gender { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

    }
}
