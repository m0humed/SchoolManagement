using MediatR;
using Schoolmanagement.Domain.Results;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.Autherization.Queries
{
    public record GetUserClaimsQuery : IRequest<Response<ManageUserClaimsResult>>
    {
        public string UserName { get; set; } = null!;
    }
}
