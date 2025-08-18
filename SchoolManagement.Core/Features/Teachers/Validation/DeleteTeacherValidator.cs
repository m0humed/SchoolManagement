using FluentValidation;
using SchoolManagement.Core.Features.Teachers.Commands;

namespace SchoolManagement.Core.Features.Teachers.Validation
{
    public class DeleteTeacherValidator : AbstractValidator<DeleteTeacherCommand>
    {
        public DeleteTeacherValidator()
        {
            validetor();
        }

        public void validetor()
        {
            RuleFor(x => x.ssn)
                .Length(14)
                .WithErrorCode("400")
                .WithMessage("SSN must be 14 digits long")
                ;
        }
    }
}
