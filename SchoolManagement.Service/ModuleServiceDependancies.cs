using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Service.IServices;
using SchoolManagement.Service.Services;

namespace SchoolManagement.Service
{
    public static class ModuleServiceDependancies
    {
        public static IServiceCollection AddServiceDependancies(this IServiceCollection services)
        {
            services.AddScoped<IClassService , ClassService>();
            services.AddScoped<ISubjectService , SubjectService>();
            return services;
        }

    }
}
