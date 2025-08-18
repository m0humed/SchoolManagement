using MediatR;
using Schoolmanagement.Domain.Entities;

namespace SchoolManagement.Core.Features.Teachers.Commands
{
    public record AddTeacherCommand(Teacher Teacher) : IRequest
    {


    }
}
