using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Schoolmanagement.Domain.Entities.Identity;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Service
{
    public static class ServiceIdentityRegisturation
    {
        public static IServiceCollection SrviceIdentityRegisturation(this IServiceCollection Services)
        {
            Services.AddIdentity<User, IdentityRole>(
                options =>
                {
                    options.SignIn.RequireConfirmedEmail = true;
                    // Password settings.
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 0;

                    // Lockout settings.
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    options.Lockout.MaxFailedAccessAttempts = 5;
                    options.Lockout.AllowedForNewUsers = true;

                    // User settings.
                    options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                    options.User.RequireUniqueEmail = false;
                }
                ).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            return Services;
        }
    }
}
