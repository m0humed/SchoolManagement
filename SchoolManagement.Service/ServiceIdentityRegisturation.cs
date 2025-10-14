using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Schoolmanagement.Domain.Entities.Identity;
using Schoolmanagement.Domain.Helper.Bind;
using SchoolManagement.Infrastructure.Data;
using System.Text;

namespace SchoolManagement.Service
{
    public static class ServiceIdentityRegisturation
    {
        public static IServiceCollection SrviceIdentityRegisturation(this IServiceCollection Services, IConfiguration configuration)
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

                    options.SignIn.RequireConfirmedEmail = true;
                    options.SignIn.RequireConfirmedPhoneNumber = false;
                    options.SignIn.RequireConfirmedAccount = false;

                    // User settings.
                    options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                    options.User.RequireUniqueEmail = false;
                }
                ).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


            //Bind JWT Settings & Email Settings
            var JwtSettings = new JwtSettings();
            configuration.GetSection(nameof(JwtSettings)).Bind(JwtSettings);
            Services.AddSingleton(JwtSettings);

            var EmailSettings = new EmailSettings();
            configuration.GetSection(nameof(EmailSettings)).Bind(EmailSettings);
            Services.AddSingleton(EmailSettings);

            // Add Authentication
            Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = JwtSettings.ValidateIssuer,
                    ValidIssuers = new[] { JwtSettings.issuer },
                    ValidateIssuerSigningKey = JwtSettings.ValidateIssuerSignInKey,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtSettings.secret)),
                    ValidAudience = JwtSettings.audience,
                    ValidateAudience = JwtSettings.ValidateAudience,
                    ValidateLifetime = JwtSettings.ValidateLifeTime,
                };
            }
            );

            //Swagger Gn
            Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "School Project", Version = "v1" });
                c.EnableAnnotations();

                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
            {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
            Array.Empty<string>()
            }
           });
            });

            // Add Ploices to Use UserClaims 
            Services.AddAuthorization(
                    option =>
                    {
                        option.AddPolicy("Create Student",
                            policy => policy.RequireClaim("Create Student", "true")
                            );
                        option.AddPolicy("Update Student",
                            policy => policy.RequireClaim("Update Student", "true")
                            );
                        option.AddPolicy("Delete Student",
                            policy => policy.RequireClaim("Delete Student", "true")
                            );

                    }
                );

            return Services;
        }
    }
}
