using MediatR;
using Schoolmanagement.Domain.Enums;
using SchoolManagement.Core.Bases;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Core.Features.Users.Commands
{
    public record AddUserCommand : IRequest<Response<bool>>
    {
        [Required]
        public string SSN { get; set; } = null!;
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Fullname { get; set; } = null!;
        public Gender Gender { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; } = null!;
        [PasswordPropertyText]
        public string ConfirmedPassword { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Phone]
        public string? PhoneNumber { get; set; } = null!;
        public string? Address { get; set; } = null!;



    }
}
