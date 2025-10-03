using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Schoolmanagement.Domain.Entities.Identity;
using Schoolmanagement.Domain.Enums;

namespace SchoolManagement.Infrastructure.Data_Seeding
{
    public static class RoleSeeding
    {
        public static async Task Create(RoleManager<IdentityRole> _roleManager)
        {
            var userCounts = await _roleManager.Users.CountAsync();
            if (userCounts <= 0)
            {
                var user = new User()
                {
                    FullName = "Mohamed Ahmed Mohamed",
                    Address = "El3basya",
                    Email = "Mohamed@Email.com",
                    EmailConfirmed = true,
                    PhoneNumber = "01276611626",
                    NormalizedEmail = "Mohamed@Email.com".Normalize(),
                    ssn = "30308045566744",
                    UserName = "M0hamud",
                    Gender = Gender.Male,
                    NormalizedUserName = "M0hamud".Normalize()
                };
                await _roleManager.CreateAsync(user, "password");
                await _roleManager.AddToRoleAsync(user, Enum.GetName(RoleEnums.SuperAdmin)!);
            }
        }
    }
}
