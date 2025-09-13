using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.Users.Commands;
using SchoolManagement.Core.Resources;

namespace SchoolManagement.Core.Features.Users.Validation.CommandValidations
{
    public class AddUserValidation : AbstractValidator<AddUserCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localization;

        #endregion
        public AddUserValidation(IStringLocalizer<SharedResources> localizer)
        {
            _localization = localizer;
            NameValidation();
            PasswordValidion();
            SSNValidation();

        }

        private void SSNValidation()
        {
            RuleFor(x => x.SSN)
            .NotEmpty().WithMessage("SSN is required Falidation Rule.")
            .Matches(@"^(2|3)\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\d|3[01])\d{7}$")
            .WithMessage("Invalid Egyptian SSN format.");
        }

        private void PasswordValidion()
        {
            RuleFor(x => x.Password)
                .Equal(x => x.ConfirmedPassword)
                .WithMessage(_localization[SharedResourcesKeys.PassNotEqual]);
        }

        private void NameValidation()
        {
            RuleFor(x => x.Fullname)
                .NotNull().WithMessage(_localization[SharedResourcesKeys.nullValue])
                .NotEmpty().WithMessage(_localization[SharedResourcesKeys.emptyValue]);

            RuleFor(x => x.Fullname)
              .Must(fullName =>
              {
                  if (string.IsNullOrWhiteSpace(fullName)) return false;

                  // Split by spaces, ignoring extra spaces
                  var parts = fullName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                  return parts.Length == 3;
              })
               .WithMessage(_localization[SharedResourcesKeys.Name3]);
        }
    }
}
