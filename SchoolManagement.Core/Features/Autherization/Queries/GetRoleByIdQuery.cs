using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Autherization.Results;
namespace SchoolManagement.Core.Features.Autherization.Queries
{
    public record GetRoleByIdQuery : IRequest<Response<GetRoleByIdResult>>
    {
        public string Id { get; set; } = null!;
    }
}
