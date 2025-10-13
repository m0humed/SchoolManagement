using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Mail.Commands;

namespace SchoolManagement.Core.Features.Mail.Handlers
{
    public partial class CommandHandlers : IRequestHandler<SendEmailCommand, Response<bool>>
    {
        public async Task<Response<bool>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var result = await _emailService.SendEmailAsync(request.Email, request.Message);
            if (result == "Success")
                return Success(true);
            return BadRequest<bool>();
        }
    }
}
