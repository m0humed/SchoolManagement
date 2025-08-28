using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.Class.Commands;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Core.Features.Class.Validation
{
    public class AddClassValidation : AbstractValidator<AddClassCommand>
    {

        #region Fields
        private readonly IClassService _service;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region CTOR
        public AddClassValidation(IClassService service, IStringLocalizer<SharedResources> localizer)
        {
            _service = service;
            _localizer = localizer;
            ApplyValidationRule();

        }
        #endregion

        #region Actions

        public void ApplyValidationRule()
        {
            RuleFor(x => new { x.c.Id, x.c.ClassNumber, x.c.Stage })
                .MustAsync(async (value, cancellation) =>
                    !await _service.ExistsByStageAndClassNumberAsync(value.Stage, value.ClassNumber, value.Id))
                .WithMessage(_localizer[SharedResourcesKeys.repetedClassNumber]);


        }

        #endregion
    }
}
