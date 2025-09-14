using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.Users.Commands;
using SchoolManagement.Core.Resources;

namespace SchoolManagement.Core.Features.Users.Validation.CommandValidations
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        #region Fields

        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        public ChangePasswordCommandValidator(IStringLocalizer<SharedResources> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            PasswordValidator();
        }

        void PasswordValidator()
        {
            RuleFor(x => x)
                .Must(Commands => Commands.NewPassword.Equals(Commands.ConfirmNewPassword))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.PassNotEqual]);



        }


    }
}
