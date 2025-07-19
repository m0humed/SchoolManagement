using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Infrastructure.IRepositories;
using SchoolManagement.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure
{
    public static class ModuleInfrastructureDependancies
    {
        public static IServiceCollection AddInfrastructureDependancies(this IServiceCollection services)
        {
            // Register your repositories and other infrastructure services here
            services.AddScoped<IClassRepositoy, ClassRepositoy>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            // services.AddScoped<IStudentRepository, StudentRepository>();
            // services.AddScoped<IUnitOfWork, UnitOfWork>();
            // services.AddDbContext<SchoolManagementDbContext>(options => 
            //     options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
