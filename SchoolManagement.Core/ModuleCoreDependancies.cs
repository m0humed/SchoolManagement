using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Core.Behaviors;
using SchoolManagement.Core.Features.Teachers.Validation;
using System.Reflection;

namespace SchoolManagement.Core
{
    public static class ModuleCoreDependancies
    {
        public static IServiceCollection AddCoreDependancies(this IServiceCollection services)
        {
            #region inject MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            #endregion

            #region inject AutomMapper
            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());
            #endregion

            #region Inject Validation behavior
            // Get Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // 
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddValidatorsFromAssemblyContaining<AddTeacherValidator>();
            #endregion


            return services;
        }

    }
}
