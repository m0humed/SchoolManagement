using MediatR;
using Schoolmanagement.Domain.Dtos;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.Autherization.Commands
{
    public record UpdateUserRolesCommand(UpdateUserRoleRequest UpdateUserRoleRequest) : IRequest<Response<bool>>
    {

    }
}
