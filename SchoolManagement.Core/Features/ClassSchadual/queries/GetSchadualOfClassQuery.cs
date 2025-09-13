
using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.ClassSchadual.Results;

namespace SchoolManagement.Core.Features.ClassSchadual.queries
{
    public record GetSchadualOfClassQuery : IRequest<Response<IEnumerable<GetClassSchadualResult>>>
    {
        public Guid ClassId { get; set; }
    }
}
