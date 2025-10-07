using Microsoft.AspNetCore.Identity;
using Schoolmanagement.Domain.Dtos;
using Schoolmanagement.Domain.Results;

namespace SchoolManagement.Service.IServices
{
    public interface IAutherizationService : IService<IdentityRole, string>
    {
        Task<List<UserRoles>> GetRolesForUserAsync(string userName);
        Task<ManageUserClaimsResult> GetClaimsForUserAsync(string userName);
        Task<bool> UpdateClaimsForUserAsync(UpdateUserClaimsRequest request);
        Task<bool> IsExistByIdAsync(string id);
        Task<bool> RoleUsedAsync(string RoleName);
        Task<bool> UpdateUserRolesAsync(UpdateUserRoleRequest request);
    }
}
