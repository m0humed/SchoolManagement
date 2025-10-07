using MediatR;
using Schoolmanagement.Domain.Dtos;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.Autherization.Commands
{
    public class UpdateRoleCommand : UpdateRoleRequest, IRequest<Response<bool>>
    {

    }
}
