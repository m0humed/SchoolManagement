using FluentValidation;
using SchoolManagement.Core.Features.Teachers.Commands;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Core.Features.Teachers.Validation
{
    public class AddTeacherValidator : AbstractValidator<AddTeacherCommand>
    {
        #region Fields
        private readonly ITeacherService _service;
        #endregion

        #region CTOR
        public AddTeacherValidator(ITeacherService service)
        {
            ApplyValidationRule();
            customvalidation();
            _service = service;
        }
        #endregion

        #region Actions

        public void ApplyValidationRule()
        {

            RuleFor(x => x.Teacher.ssn)
            .NotEmpty().WithMessage("SSN is required Falidation Rule.")
            .Matches(@"^(2|3)\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\d|3[01])\d{7}$")
            .WithMessage("Invalid Egyptian SSN format.");

            RuleFor(x => x.Teacher.FirstName)
                .MaximumLength(15)
                .MinimumLength(2)
                .Matches(@"^\w+");
        }

        public void customvalidation()
        {
            RuleFor(x => x.Teacher.FirstName)
                .MustAsync(async (key, Cancellationtoken) => !await _service.isNameExist(key))
                .WithMessage("this Name is already in database");
        }
        #endregion

    }
}
