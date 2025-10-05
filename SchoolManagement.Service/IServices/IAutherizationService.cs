using Microsoft.AspNetCore.Identity;
using Schoolmanagement.Domain.Dtos;

namespace SchoolManagement.Service.IServices
{
    public interface IAutherizationService : IService<IdentityRole, string>
    {
        Task<List<UserRoles>> GetRolesForUserAsync(string userName);
        Task<bool> IsExistByIdAsync(string id);
        Task<bool> RoleUsedAsync(string RoleName);
    }
}
