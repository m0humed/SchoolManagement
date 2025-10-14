using Schoolmanagement.Domain.Common;
using Schoolmanagement.Domain.Entities.Identity;

namespace SchoolManagement.Service.IServices
{
    public interface IApplicationUserService
    {
        Task<ServiceResult> AddUserAsync(User user, string password);
        Task<ServiceResult> GenerateConfermationUrlAsync(User user);
        Task<ServiceResult> VerifyConfermationUrlAsync(string userId, string code);
    }
}
