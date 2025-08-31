using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.ClassSchadual.Commands;
using SchoolManagement.Core.Resources;

namespace SchoolManagement.Core.Features.ClassSchadual.Handlers
{
    public class ClassSchadualCommandHandler : ResponseHandler, IRequestHandler<AddClassSchadualCommand, Response<bool>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        public ClassSchadualCommandHandler(IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
        }

        public Task<Response<bool>> Handle(AddClassSchadualCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
