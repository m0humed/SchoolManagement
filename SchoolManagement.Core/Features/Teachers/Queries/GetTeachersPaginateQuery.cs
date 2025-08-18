using MediatR;
using Schoolmanagement.Domain.Enums;
using SchoolManagement.Core.Features.Teachers.Results;
using SchoolManagement.Core.Wrappers;

namespace SchoolManagement.Core.Features.Teachers.Queries
{
    public class GetTeachersPaginateQuery : IRequest<PaginationResult<GetTeachersPaginateResult>>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public OrderingTeachers? OrderBy { get; set; }

        public string? Search { get; set; }
    }
}
