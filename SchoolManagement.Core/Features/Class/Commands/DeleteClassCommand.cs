using MediatR;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.Class.Commands
{
    public record DeleteClassCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
    }
}
