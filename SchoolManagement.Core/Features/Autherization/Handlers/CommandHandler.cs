using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Autherization.Commands;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Core.Features.Autherization.Handlers
{
    public class CommandHandler : ResponseHandler, IRequestHandler<AddRoleCommand, Response<bool>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IAutherizationService _autherizationService;
        #endregion
        public CommandHandler(IStringLocalizer<SharedResources> localizer,
                                IAutherizationService autherizationService) : base(localizer)
        {
            _localizer = localizer;
            _autherizationService = autherizationService;
        }

        public async Task<Response<bool>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                    return NullRequest<bool>();
                var role = new IdentityRole();
                role.Name = request.RoleName;
                role.NormalizedName = request.RoleName.Normalize();
                await _autherizationService.AddAsync(role);
                return Created(true);
            }
            catch
            {
                return ServerError<bool>(_localizer[SharedResourcesKeys.CanNotSave]);
            }
        }
    }
}
