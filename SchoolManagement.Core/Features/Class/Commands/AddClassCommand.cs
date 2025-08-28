namespace SchoolManagement.Core.Features.Class.Commands
{
    using MediatR;
    using Schoolmanagement.Domain.Entities;
    using SchoolManagement.Core.Bases;
    public record AddClassCommand(Class c) : IRequest<Response<bool>>
    {

    }
}
