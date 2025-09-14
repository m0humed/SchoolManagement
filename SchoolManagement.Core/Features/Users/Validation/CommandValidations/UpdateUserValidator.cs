using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.Users.Commands;
using SchoolManagement.Core.Resources;

namespace SchoolManagement.Core.Features.Users.Validation.CommandValidations
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localization;

        #endregion

        #region Constructors
        public UpdateUserValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localization = localizer;
            NameValidation();
            SSNValidation();

        }
        #endregion

        #region Validators
        private void SSNValidation()
        {
            RuleFor(x => x.ssn)
            .NotEmpty().WithMessage("SSN is required Falidation Rule.")
            .Matches(@"^(2|3)\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\d|3[01])\d{7}$")
            .WithMessage("Invalid Egyptian SSN format.");
        }


        private void NameValidation()
        {
            RuleFor(x => x.FullName)
                .NotNull().WithMessage(_localization[SharedResourcesKeys.nullValue])
                .NotEmpty().WithMessage(_localization[SharedResourcesKeys.emptyValue]);

            RuleFor(x => x.FullName)
              .Must(fullName =>
              {
                  if (string.IsNullOrWhiteSpace(fullName)) return false;

                  // Split by spaces, ignoring extra spaces
                  var parts = fullName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                  return parts.Length == 3;
              })
               .WithMessage(_localization[SharedResourcesKeys.Name3]);
        }
        #endregion

    }
}
