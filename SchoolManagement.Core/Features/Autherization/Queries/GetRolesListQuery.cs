using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Autherization.Results;

namespace SchoolManagement.Core.Features.Autherization.Queries
{
    public record GetRolesListQuery : IRequest<Response<List<RolesListResult>>>
    {
    }
}
