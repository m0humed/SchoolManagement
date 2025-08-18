namespace SchoolManagement.Core.Features.Teachers.Commands
{
    using MediatR;
    using SchoolManagement.Core.Bases;

    public record DeleteTeacherCommand : IRequest<Response<string>>
    {
        public string ssn { get; set; }
    }
}
