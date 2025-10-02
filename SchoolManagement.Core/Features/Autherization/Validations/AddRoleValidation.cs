using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.Autherization.Commands;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Core.Features.Autherization.Validations
{
    public class AddRoleValidation : AbstractValidator<AddRoleCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IAutherizationService _autherizationService;
        #endregion

        #region Constructors
        public AddRoleValidation(IStringLocalizer<SharedResources> localizer
                                 , IAutherizationService autherization)
        {
            _localizer = localizer;
            _autherizationService = autherization;
            IsExistValidator();
        }
        #endregion

        #region Validators
        private void IsExistValidator()
        {
            RuleFor(x => x.RoleName)
                .MustAsync(async (x, CancellationToken) => !await _autherizationService.ExistsAsync(x))
                .WithMessage(_localizer[SharedResourcesKeys.UserNameAlreadyExist]);
        }

        #endregion
    }
}
