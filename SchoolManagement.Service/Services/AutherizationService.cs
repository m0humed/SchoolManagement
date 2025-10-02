using Microsoft.AspNetCore.Identity;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Service.Services
{
    public class AutherizationService : IAutherizationService
    {
        #region Fields
        private readonly RoleManager<IdentityRole> _roleManager;

        #endregion
        #region Constructors
        public AutherizationService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        #endregion
        public async Task AddAsync(IdentityRole entity)
        {
            var result = await _roleManager.CreateAsync(entity);
            if (!result.Succeeded)
            {
                throw new Exception();
            }
        }

        public Task DeleteAsync(string roleName)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsAsync(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }

        public Task<IEnumerable<IdentityRole>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IdentityRole> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IdentityRole entity)
        {
            throw new NotImplementedException();
        }
    }
}
