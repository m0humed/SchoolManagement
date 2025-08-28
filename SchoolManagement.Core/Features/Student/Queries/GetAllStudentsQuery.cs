using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Student.Results;

namespace SchoolManagement.Core.Features.Student.Queries
{
    public record GetAllStudentsQuery : IRequest<Response<IEnumerable<GetStudentDataResult>>>
    {
    }
}
