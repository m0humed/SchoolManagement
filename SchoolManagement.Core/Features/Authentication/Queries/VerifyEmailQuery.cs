using MediatR;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.Authentication.Queries
{
    public class VerifyEmailQuery : IRequest<Response<bool>>
    {
        public string UserId { get; set; } = null!;

        public string Code { get; set; } = null!;

    }
}
