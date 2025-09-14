using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.Users.Commands;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Core.Features.Users.Validation.CommandValidations
{
    public class AddUserValidation : AbstractValidator<AddUserCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localization;
        private readonly IUserService _userService;

        #endregion

        #region Constructors
        public AddUserValidation(IStringLocalizer<SharedResources> localizer, IUserService userService)
        {
            _userService = userService;
            _localization = localizer;
            NameValidation();
            PasswordValidion();
            SSNValidation();
            PhoneNumberValidation();

        }

        #endregion

        #region Methods
        private void SSNValidation()
        {
            RuleFor(x => x.SSN)
                .NotEmpty().WithMessage("SSN is required Falidation Rule.")
                .Matches(@"^(2|3)\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\d|3[01])\d{7}$")
                .WithMessage("Invalid Egyptian SSN format.");

            RuleFor(x => x)
                .MustAsync(async (command, cancellation) => !await _userService.IsSSNExist(command.Id, command.SSN))
                .WithMessage(_localization[SharedResourcesKeys.repeatedSSN]);
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


        private void PhoneNumberValidation()
        {

            //RuleFor(x => x.PhoneNumber)
            //    .NotEmpty()
            //    .WithMessage(_localization[SharedResourcesKeys.emptyValue])
            //    .NotNull()
            //    .WithMessage(_localization[SharedResourcesKeys.nullValue])
            //    .Length(11)
            //    .WithMessage(_localization[SharedResourcesKeys.PhoneNumberLength]);


            RuleFor(x => x)
                .MustAsync(async (command, cancellation) => !await _userService.IsPhoneNumberExist(command.Id, command.PhoneNumber ?? ""))
                .WithMessage(_localization[SharedResourcesKeys.repeatedPhone]);
        }
        #endregion
    }
}
