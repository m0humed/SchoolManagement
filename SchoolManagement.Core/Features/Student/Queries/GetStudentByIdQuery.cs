using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Student.Results;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Core.Features.Student.Queries
{
    public class GetStudentByIdQuery : IRequest<Response<GetStudentDataResult>>
    {
        [Required]
        public string Id { get; set; } = null!;

    }
}
