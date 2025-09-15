using Schoolmanagement.Domain.Entities.Identity;

namespace SchoolManagement.Service.IServices
{
    public interface IAuthenticationService
    {
        Task<string> CreateJWTToken(User user);

    }
}
