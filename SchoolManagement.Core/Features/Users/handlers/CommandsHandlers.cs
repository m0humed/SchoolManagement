using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Schoolmanagement.Domain.Entities.Identity;
using Schoolmanagement.Domain.Enums;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Users.Commands;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Core.Features.Users.handlers
{
    public class CommandsHandlers : ResponseHandler, IRequestHandler<AddUserCommand, Response<bool>>
                                                   , IRequestHandler<UpdateUserCommand, Response<bool>>
                                                   , IRequestHandler<DeleteUserCommand, Response<bool>>
                                                   , IRequestHandler<ChangePasswordCommand, Response<bool>>

    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IApplicationUserService _applicationUserService;
        private readonly IEmailService _emailService;
        #endregion

        #region Constructors
        public CommandsHandlers(IStringLocalizer<SharedResources> localizer, UserManager<User> userManager, IMapper mapper, IApplicationUserService applicationUserService, IEmailService emailService) : base(localizer)
        {
            _localizer = localizer;
            _userManager = userManager;
            _mapper = mapper;
            _applicationUserService = applicationUserService;
            _emailService = emailService;
        }
        #endregion

        #region Handlers

        public async Task<Response<bool>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                return BadRequest<bool>(_localizer[SharedResourcesKeys.nullValue]);
            //Check Email
            if (request.Email != null)
            {
                var Uemail = await _userManager.FindByEmailAsync(request.Email);
                if (Uemail != null)
                {
                    return BadRequest<bool>(_localizer[SharedResourcesKeys.EmailAlreadyExist]);
                }
            }

            //Check Username

            if (request.UserName == null)
                return BadRequest<bool>(_localizer[SharedResourcesKeys.nullValue]);

            var UUserName = await _userManager.FindByNameAsync(request.UserName);
            if (UUserName != null)
            {
                return BadRequest<bool>(_localizer[SharedResourcesKeys.UserNameAlreadyExist]);
            }

            var mappedUser = _mapper.Map<User>(request);
            if (mappedUser != null)
            {
                mappedUser.Id = Guid.NewGuid().ToString();
                var AddResult = await _userManager.CreateAsync(mappedUser, request.Password);
                if (AddResult.Succeeded)
                {
                    var assignResult = await _userManager.AddToRoleAsync(mappedUser, Enum.GetName(RoleEnums.User)!);
                    if (assignResult.Succeeded)
                    {
                        var createdUrl = await _applicationUserService.GenerateConfermationUrlAsync(mappedUser);
                        if (!createdUrl.Success)
                            return ServerError<bool>(_localizer[SharedResourcesKeys.CanNotGUrl]);
                        var SendUrlResult = await _emailService.SendVerifyurlByEmailAsync(mappedUser.Email!, createdUrl.Message);
                        if (!SendUrlResult.Success)
                            return ServerError<bool>(_localizer[SharedResourcesKeys.CanNotSendUrl]);
                        return Created(true);
                    }
                    else
                    {
                        return ServerError<bool>(_localizer[SharedResourcesKeys.AssignRoleError]);
                    }

                }
                else
                    return ServerError<bool>(_localizer[SharedResourcesKeys.CanNotSave]);

            }
            return ServerError<bool>(_localizer[SharedResourcesKeys.UnValidCast]);
        }

        public async Task<Response<bool>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                return BadRequest<bool>(_localizer[SharedResourcesKeys.nullValue]);

            // Check Email
            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                var existingEmailUser = await _userManager.FindByEmailAsync(request.Email);
                if (existingEmailUser != null && !request.Id.ToString().Equals(existingEmailUser.Id, StringComparison.OrdinalIgnoreCase))
                {
                    return BadRequest<bool>(_localizer[SharedResourcesKeys.EmailAlreadyExist]);
                }
            }

            // Check Username
            if (string.IsNullOrWhiteSpace(request.Username))
                return BadRequest<bool>(_localizer[SharedResourcesKeys.nullValue]);

            var existingUserNameUser = await _userManager.FindByNameAsync(request.Username);
            if (existingUserNameUser != null && !request.Id.ToString().Equals(existingUserNameUser.Id, StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest<bool>(_localizer[SharedResourcesKeys.UserNameAlreadyExist]);
            }

            // Cast request to user
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null)
            {
                return NotFound<bool>(_localizer[SharedResourcesKeys.error]);
            }

            // Map updated fields from request to user entity
            _mapper.Map(request, user);

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return Updated<bool>();
            }
            return ServerError<bool>(_localizer[SharedResourcesKeys.error]);



        }

        public async Task<Response<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                return BadRequest<bool>(_localizer[SharedResourcesKeys.nullValue]);

            var user = await _userManager.FindByIdAsync(request.id);
            if (user == null)
                return NotFound<bool>(_localizer[SharedResourcesKeys.notFound]);

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return Deleted<bool>();
            }
            return BadRequest<bool>(_localizer[SharedResourcesKeys.DeleteField]);
        }

        public async Task<Response<bool>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {

            if (request is null)
                return BadRequest<bool>(_localizer[SharedResourcesKeys.nullValue]);

            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
                return NotFound<bool>(_localizer[SharedResourcesKeys.notFound]);

            var result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);
            if (result.Succeeded)
                return Success(true);

            return BadRequest<bool>(_localizer[SharedResourcesKeys.FalseOldPassword]);

        }




        #endregion
    }
}
