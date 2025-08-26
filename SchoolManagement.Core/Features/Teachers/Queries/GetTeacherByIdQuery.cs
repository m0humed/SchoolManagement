using MediatR;

namespace SchoolManagement.Core.Features.Teachers.Queries
{
    using Schoolmanagement.Domain.Entities;
    using SchoolManagement.Core.Bases;
    using System.ComponentModel.DataAnnotations;

    public record GetTeacherByIdQuery : IRequest<Response<Teacher>>
    {
        [Required]
        public string ssn { get; set; } = null!;
    }
}
