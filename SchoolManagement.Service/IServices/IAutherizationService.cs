using Microsoft.AspNetCore.Identity;

namespace SchoolManagement.Service.IServices
{
    public interface IAutherizationService : IService<IdentityRole, string>
    {
        Task<bool> IsExistByIdAsync(string id);
        Task<bool> RoleUsedAsync(string RoleName);
    }
}
