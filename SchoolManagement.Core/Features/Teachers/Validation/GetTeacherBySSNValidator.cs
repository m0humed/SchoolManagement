using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.Teachers.Queries;
using SchoolManagement.Core.Resources;

namespace SchoolManagement.Core.Features.Teachers.Validation
{
    public class GetTeacherBySSNValidator : AbstractValidator<GetTeacherByIdQuery>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructors
        public GetTeacherBySSNValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            CheckSSN();
        }
        #endregion

        #region Validator Methods
        public void CheckSSN()
        {
            RuleFor(x => x.ssn)
            .NotEmpty().WithMessage($"{_localizer[SharedResourcesKeys.emptySSN]}")
            .Matches(@"^(2|3)\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\d|3[01])\d{7}$")
            .WithMessage($"{_localizer[SharedResourcesKeys.notValidSSN]}");

        }

        #endregion

    }
}
