using FluentValidation;
using SchoolManagement.Core.Features.Student.Commands;

namespace SchoolManagement.Core.Features.Student.Validation
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        #region Fields

        #endregion

        #region Constructors
        public AddStudentValidator()
        {
            CluturalRule();

        }
        #endregion

        #region Validators

        private void CluturalRule()
        {
            RuleFor(x => x.firstNameAr)
           .Matches(@"^[\u0600-\u06FF\s]+$")
           .WithMessage("Arabic name must contain only Arabic letters.");

            RuleFor(x => x.secondNameAr)
            .Matches(@"^[\u0600-\u06FF\s]+$")
            .WithMessage("Arabic name must contain only Arabic letters.");

            RuleFor(x => x.thirdNameAr)
            .Matches(@"^[\u0600-\u06FF\s]+$")
            .WithMessage("Arabic name must contain only Arabic letters.");

            // English Name must be written only in English letters
            RuleFor(x => x.firstNameEn)
                .Matches(@"^[A-Za-z\s]+$")
                .WithMessage("English name must contain only English letters.");
            RuleFor(x => x.secondNameEn)
                .Matches(@"^[A-Za-z\s]+$")
                .WithMessage("English name must contain only English letters.");
            RuleFor(x => x.thirdNameEn)
                            .Matches(@"^[A-Za-z\s]+$")
                            .WithMessage("English name must contain only English letters.");


        }

        #endregion

    }
}
