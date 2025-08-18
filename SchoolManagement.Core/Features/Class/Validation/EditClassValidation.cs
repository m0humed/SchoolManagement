using FluentValidation;
using SchoolManagement.Core.Features.Class.Commands;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Core.Features.Class.Validation
{
    public class EditClassValidation : AbstractValidator<EditClassCommand>
    {

        #region Fields
        private readonly IClassService _service;
        #endregion

        #region CTOR
        public EditClassValidation(IClassService service)
        {
            ApplyValidationRule();
            _service = service;
        }
        #endregion

        #region Actions

        public void ApplyValidationRule()
        {
            RuleFor(x => new { x.Stage, x.ClassNumber, x.Id })
                .MustAsync(async (value, cancellation) =>
                    !await _service.ExistsByStageAndClassNumberAsync(value.Stage, value.ClassNumber, value.Id))
                .WithMessage("A class with the same stage and class number already exists.");


        }

        #endregion
    }
}
