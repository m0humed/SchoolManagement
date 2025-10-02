using Schoolmanagement.Domain.Entities.Identity;
using Schoolmanagement.Domain.Results;

namespace SchoolManagement.Service.IServices
{
    public interface IAuthenticationService
    {
        Task<JwtAuthenticationResult> CreateJWTToken(User user);
        public Task<JwtAuthenticationResult> GetRefreshToken(string accessToken, string refreshToken);
        public Task<string> ValidateToken(string AccessToken);
    }
}
