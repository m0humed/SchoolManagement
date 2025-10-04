using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.Autherization.Commands;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Core.Features.Autherization.Validations
{
    public class DeleteRoleValidation : AbstractValidator<DeleteRoleCommand>
    {

        #region Fields
        private readonly IAutherizationService _authservese;
        private readonly IUserService _userService;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion
        #region Constructors
        public DeleteRoleValidation(IAutherizationService authservese, IUserService userService, IStringLocalizer<SharedResources> localizer)
        {
            _authservese = authservese;
            _userService = userService;
            _localizer = localizer;
            Validate();
            IsExistValidator();
        }
        #endregion

        #region Validators
        private void IsExistValidator()
        {
            RuleFor(x => x.RoleName)
                .MustAsync(async (x, CancellationToken) => await _authservese.ExistsAsync(x))
                .WithMessage(_localizer[SharedResourcesKeys.RoleNotExist]);
        }

        private void Validate()
        {
            RuleFor(x => x.RoleName)
                .MustAsync(async (x, CancellationToken) => !await _authservese.RoleUsedAsync(x))
                .WithMessage(_localizer[SharedResourcesKeys.RoleAlreadyUsed]);
        }
        #endregion
    }
}
