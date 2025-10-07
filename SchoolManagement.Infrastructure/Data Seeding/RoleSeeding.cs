using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Schoolmanagement.Domain.Enums;

namespace SchoolManagement.Infrastructure.Data_Seeding
{
    public static class RoleSeeding
    {
        public static async Task SeedAsync(this RoleManager<IdentityRole> _roleManager)
        {
            var userCounts = await _roleManager.Roles.CountAsync();
            if (userCounts <= 0)
            {
                foreach (var role in Enum.GetNames<RoleEnums>())
                {
                    var identityRole = new IdentityRole(role);
                    await _roleManager.CreateAsync(identityRole);
                }

            }
        }
    }
}
