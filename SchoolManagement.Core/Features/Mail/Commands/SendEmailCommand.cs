using MediatR;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.Mail.Commands
{
    public class SendEmailCommand : IRequest<Response<bool>>
    {
        public string Email { get; set; } = null!;
        public string Message { get; set; } = null!;
    }
}
