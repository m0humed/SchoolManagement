using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.Mail.Commands;
using SchoolManagement.Core.Resources;

namespace SchoolManagement.Core.Features.Mail.Validation
{
    public class SendEmailValidator : AbstractValidator<SendEmailCommand>
    {
        #region Field
        public IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructors
        public SendEmailValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            NotEmptyCheck();
            EmailChecked();
        }


        #endregion
        #region Validators

        private void NotEmptyCheck()
        {
            RuleFor(x => x.Message)
                .NotNull()
                .WithMessage(_localizer[SharedResourcesKeys.nullValue])
                .NotEmpty()
                .WithMessage(SharedResourcesKeys.emptyValue);

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage(_localizer[SharedResourcesKeys.nullValue])
                .NotEmpty()
                .WithMessage(SharedResourcesKeys.emptyValue);
        }
        private void EmailChecked()
        {

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage(SharedResourcesKeys.NotEmail);
        }

        #endregion

    }
}
