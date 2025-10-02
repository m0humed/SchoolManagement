using MediatR;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.Authentication.Queries
{
    public record ValidateTokenQuery : IRequest<Response<string>>
    {
        public string AccessToken { get; set; } = null!;
    }
}
