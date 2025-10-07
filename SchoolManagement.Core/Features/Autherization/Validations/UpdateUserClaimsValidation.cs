using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.Autherization.Commands;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Core.Features.Autherization.Validations
{
    public class UpdateUserClaimsValidation : AbstractValidator<UpdateUserClaimsCommand>
    {
        #region Fields
        private readonly IUserService _UserService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion

        #region Constructors
        public UpdateUserClaimsValidation(IUserService autherizationService, IStringLocalizer<SharedResources> stringLocalizer)
        {
            _UserService = autherizationService;
            _stringLocalizer = stringLocalizer;
            IsExistValidator();
        }
        #endregion

        #region Methods
        void IsExistValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage(_stringLocalizer[SharedResourcesKeys.emptyValue]);
            RuleFor(x => x.UserName)
                .MustAsync(async (x, CancellationToken) => await _UserService.IsUserNameExistAsync(x))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.notFound]);
        }
        #endregion
    }
}
