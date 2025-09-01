using MediatR;

namespace SchoolManagement.Core.Features.ClassSchadual.Commands
{

    using SchoolManagement.Core.Bases;
    public record AddClassSchadualCommand : IRequest<Response<bool>>
    {
        public Guid ClassId { get; set; }

        public Guid SubjectId { get; set; }

        public string TeacherId { get; set; } = null!;

        public DayOfWeek DayOfWeek { get; set; }

        public string StartTime { get; set; } = null!;


    }
}
