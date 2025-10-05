using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Schoolmanagement.Domain.Dtos;
using Schoolmanagement.Domain.Entities.Identity;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Service.Services
{
    public class AutherizationService : IAutherizationService
    {
        #region Fields
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        #endregion
        #region Constructors
        public AutherizationService(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
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

        public async Task DeleteAsync(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            await _roleManager.DeleteAsync(role!);
        }

        public async Task<bool> ExistsAsync(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }

        public async Task<IEnumerable<IdentityRole>> GetAllAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<IdentityRole> GetByIdAsync(string id)
        {
            return (await _roleManager.FindByIdAsync(id))!;
        }

        public async Task<List<UserRoles>> GetRolesForUserAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var userRoleNames = await _userManager.GetRolesAsync(user!);

            // Get all roles from the RoleManager
            var allRoles = await _roleManager.Roles.ToListAsync();

            var rList = new List<UserRoles>();
            foreach (var roleName in userRoleNames)
            {
                var role = allRoles.FirstOrDefault(r => r.Name == roleName);
                if (role != null)
                {
                    rList.Add(new UserRoles
                    {
                        RoleId = role.Id,
                        RoleName = role.Name!,
                        HasRole = true
                    });
                }
            }
            return rList;
        }

        public async Task<bool> IsExistByIdAsync(string id)
        {
            return await _roleManager.FindByIdAsync(id) != null;
        }

        public async Task<bool> RoleUsedAsync(string roleName)
        {
            var usersInRole = await _userManager.GetUsersInRoleAsync(roleName);
            return usersInRole != null && usersInRole.Any();
        }

        public async Task UpdateAsync(IdentityRole entity)
        {
            var currentRole = await _roleManager.FindByIdAsync(entity.Id);
            if (currentRole != null)
            {
                currentRole.Name = entity.Name;
                var result = await _roleManager.UpdateAsync(currentRole);
                if (!result.Succeeded)
                { throw new Exception(); }
            }
        }
    }
}
