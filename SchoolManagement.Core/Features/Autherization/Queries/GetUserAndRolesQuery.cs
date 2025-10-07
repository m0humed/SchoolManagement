using MediatR;
using Schoolmanagement.Domain.Results;
using SchoolManagement.Core.Bases;
namespace SchoolManagement.Core.Features.Autherization.Queries
{
    public record GetUserAndRolesQuery : IRequest<Response<GetUserAndHisRolesResult>>
    {
        public string UserName { get; set; } = null!;
    }
}
