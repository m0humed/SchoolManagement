using MediatR;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.Users.Commands
{
    public class ChangePasswordCommand : IRequest<Response<bool>>
    {
        public string Id { get; set; } = string.Empty;
        public string OldPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string ConfirmNewPassword { get; set; } = string.Empty;

    }
}
