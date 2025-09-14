using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Users.Results;

namespace SchoolManagement.Core.Features.Users.Queries
{
    public record GetUserByIdQuery : IRequest<Response<GetUserByIdResult>>
    {
        public Guid UserId { get; set; }
    }
}
