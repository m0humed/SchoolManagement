using MediatR;
using SchoolManagement.Core.Bases;
namespace SchoolManagement.Core.Features.Autherization.Commands
{
    public class DeleteRoleCommand : IRequest<Response<bool>>
    {
        public string RoleName { get; set; } = null!;

    }
}
