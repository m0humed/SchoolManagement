using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Schoolmanagement.Domain.Common;
using Schoolmanagement.Domain.Entities.Identity;
using Schoolmanagement.Domain.Enums;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Service.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        #region Fields
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUrlHelper _urlHelper;
        #endregion

        #region Constructors
        public ApplicationUserService(UserManager<User> userManager,
                                        IHttpContextAccessor contextAccessor,
                                        IUrlHelper urlHelper)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
            _urlHelper = urlHelper;
        }
        #endregion

        #region Methods
        public Task<ServiceResult> AddUserAsync(User user, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult> GenerateConfermationUrlAsync(User user)
        {
            try
            {
                var VerifyCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var requestContext = $"{_contextAccessor.HttpContext!.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";
                var returnedUrl = requestContext + _urlHelper.Action("VerifyEmail", "Authentication", new { userId = user.Id, code = VerifyCode }) ?? "Null";
                return new ServiceResult
                {
                    Success = true,
                    Message = returnedUrl,
                    ServiceError = ServiceErrorEnum.None
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    Success = false,
                    Message = ex.Message,
                    ServiceError = ServiceErrorEnum.CanNotCreateUrl
                };
            }
        }

        public async Task<ServiceResult> VerifyConfermationUrlAsync(string userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return new ServiceResult
                {
                    Success = false,
                    Message = "User ID Not Falid",
                    ServiceError = ServiceErrorEnum.NotValidUserId
                };

            var verifyResult = await _userManager.ConfirmEmailAsync(user, code);
            if (!verifyResult.Succeeded)
            {
                return new ServiceResult
                {
                    Success = false,
                    Message = string.Join(" , ", verifyResult.Errors.Select(x => x.Description)),
                    ServiceError = ServiceErrorEnum.FalseCode
                };
            }
            return new ServiceResult
            {
                Success = true,
                Message = "Email confirmed successfully.",
                ServiceError = ServiceErrorEnum.None
            };
        }
        #endregion
    }
}
