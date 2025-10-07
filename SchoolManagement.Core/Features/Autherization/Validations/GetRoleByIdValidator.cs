using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.Autherization.Queries;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.IServices;
namespace SchoolManagement.Core.Features.Autherization.Validations
{
    public class GetRoleByIdValidator : AbstractValidator<GetRoleByIdQuery>
    {
        #region Fields
        private readonly IAutherizationService _autherizationService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion

        #region Constructors
        public GetRoleByIdValidator(IAutherizationService autherizationService, IStringLocalizer<SharedResources> stringLocalizer)
        {
            _autherizationService = autherizationService;
            _stringLocalizer = stringLocalizer;
            IsExistValidator();
        }
        #endregion

        #region Methods
        void IsExistValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(_stringLocalizer[SharedResourcesKeys.emptyValue]);
            RuleFor(x => x.Id)
                .MustAsync(async (x, CancellationToken) => await _autherizationService.IsExistByIdAsync(x))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.notFound]);
        }

        #endregion

    }
}
