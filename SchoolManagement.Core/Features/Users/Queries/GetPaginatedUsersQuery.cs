using MediatR;
using SchoolManagement.Core.Features.Users.Results;
using SchoolManagement.Core.Wrappers;

namespace SchoolManagement.Core.Features.Users.Queries
{
    public record GetPaginatedUsersQuery : IRequest<PaginationResult<GetPaginatedUsersResult>>
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

    }
}
