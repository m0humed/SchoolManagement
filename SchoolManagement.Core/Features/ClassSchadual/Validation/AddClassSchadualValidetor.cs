using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.ClassSchadual.Commands;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Features.ClassSchadual.Validation
{
    public class AddClassSchadualValidetor:AbstractValidator<AddClassSchadualCommand>
    {
        private IStringLocalizer<SharedResources> _localizer;
        private readonly ITeacherService _teacherService;
        private readonly IClassService _classService;
        private readonly ISubjectService _subjectService;

        public AddClassSchadualValidetor(IStringLocalizer<SharedResources> localizer, ITeacherService teacherService, IClassService classService, ISubjectService subjectService)
        {
            _localizer = localizer;
            _teacherService = teacherService;
            ApplyExitingValidation();
            _classService = classService;
            _subjectService = subjectService;
        }

        private void ApplyExitingValidation()
        {
            RuleFor(x => x.ClassId)
                .NotNull()
                .NotEmpty()
                .WithMessage(_localizer[SharedResourcesKeys.nullValue]);
            
            RuleFor(x => x.ClassId)
                .MustAsync(async (x, CancellationToken) => await _classService.ExistsAsync(x))
                .WithMessage(_localizer[SharedResourcesKeys.notFound]);



            RuleFor(x=>x.TeacherId)
                .NotNull()
                .NotEmpty()
                .WithMessage(_localizer[SharedResourcesKeys.nullValue]);

            RuleFor(x => x.TeacherId)
                .MustAsync(async (x,CancellationToken)=>await _teacherService.ExistsAsync(x))
                .WithMessage(_localizer[SharedResourcesKeys.notFound]);
            
            RuleFor(x=>x.SubjectId)
                .NotNull()
                .NotEmpty()
                .WithMessage(_localizer[SharedResourcesKeys.nullValue]);

            RuleFor(x => x.SubjectId)
                .MustAsync(async (x,CancellationToken)=>await _subjectService.ExistsAsync(x))
                .WithMessage(_localizer[SharedResourcesKeys.notFound]);

        }
    }
}
