using Schoolmanagement.Domain.Entities.Identity;
using Schoolmanagement.Domain.Results;

namespace SchoolManagement.Service.IServices
{
    public interface IAuthenticationService
    {
        Task<JwtAuthenticationResult> CreateJWTToken(User user);

    }
}
