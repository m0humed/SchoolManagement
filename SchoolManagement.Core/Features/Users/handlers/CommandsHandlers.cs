using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Schoolmanagement.Domain.Entities.Identity;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Users.Commands;
using SchoolManagement.Core.Resources;

namespace SchoolManagement.Core.Features.Users.handlers
{
    public class CommandsHandlers : ResponseHandler, IRequestHandler<AddUserCommand, Response<bool>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public CommandsHandlers(IStringLocalizer<SharedResources> localizer, UserManager<User> userManager, IMapper mapper) : base(localizer)
        {
            _localizer = localizer;
            _userManager = userManager;
            _mapper = mapper;
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

            // Should Check os SSN
            //var SSN = await _userManager.FindByNameAsync(request.UserName);
            //if (UUserName != null)
            //{
            //    return BadRequest<bool>(_localizer[SharedResourcesKeys.UserNameAlreadyExist]);
            //}

            // Add User

            var mappedUser = _mapper.Map<User>(request);
            if (mappedUser != null)
            {
                var AddResult = await _userManager.CreateAsync(mappedUser, request.Password);
                if (AddResult.Succeeded)
                    return Created(true);
                else
                    return ServerError<bool>(_localizer[SharedResourcesKeys.CanNotSave]);
            }
            return ServerError<bool>(_localizer[SharedResourcesKeys.UnValidCast]);
        }




        #endregion
    }
}
