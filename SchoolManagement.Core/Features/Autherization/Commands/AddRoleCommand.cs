using MediatR;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.Autherization.Commands
{
    public class AddRoleCommand : IRequest<Response<bool>>
    {
        public string RoleName { get; set; } = null!;
    }
}
