using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Autherization.Commands;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Core.Features.Autherization.Handlers
{
    public class CommandHandler : ResponseHandler, IRequestHandler<AddRoleCommand, Response<bool>>,
                                                   IRequestHandler<UpdateRoleCommand, Response<bool>>,
                                                   IRequestHandler<DeleteRoleCommand, Response<bool>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IAutherizationService _autherizationService;
        private readonly IMapper _mapper;
        #endregion
        public CommandHandler(IStringLocalizer<SharedResources> localizer,
                                IAutherizationService autherizationService, IMapper mapper) : base(localizer)
        {
            _localizer = localizer;
            _autherizationService = autherizationService;
            _mapper = mapper;
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
        public async Task<Response<bool>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            // check request 
            if (request == null) return NullRequest<bool>(_localizer[SharedResourcesKeys.nullValue]);
            if (string.IsNullOrEmpty(request.RoleName)) return NullRequest<bool>(_localizer[SharedResourcesKeys.nullValue]);
            var isExist = await _autherizationService.IsExistByIdAsync(request.RoleId.ToString());
            if (!isExist)
                return NotFound<bool>();
            var role = _mapper.Map<IdentityRole>(request);
            try
            {
                await _autherizationService.UpdateAsync(role!);
                return Updated<bool>();
            }
            catch
            {
                return ServerError<bool>();
            }
        }

        public async Task<Response<bool>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _autherizationService.DeleteAsync(request.RoleName);
                return Deleted<bool>();
            }
            catch
            {
                return ServerError<bool>();
            }
        }
    }
}
