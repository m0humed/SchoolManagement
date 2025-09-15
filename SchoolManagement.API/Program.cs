
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core;
using SchoolManagement.Core.Middleware;
using SchoolManagement.Infrastructure;
using SchoolManagement.Infrastructure.Data;
using SchoolManagement.Service;
using System.Globalization;
namespace SchoolManagement.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Use CORS
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin()
                                            .AllowAnyHeader()
                                            .AllowAnyMethod()
                                            //.AllowCredentials()  // this line is not valid with AllowAnyOrigin
                                            ;
                                  });
            });
            #endregion

            //builder.WebHost.ConfigureKestrel(options =>
            //{
            //    options.ListenLocalhost(7298, listenOptions =>
            //    {
            //        listenOptions.UseHttps(); // or .UseHttps("path-to-cert.pfx", "password")
            //    });
            //});


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            // Add db context
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("local"))
                .UseLazyLoadingProxies());

            #region Depandancies injections
            // Add infrastructure dependencies
            builder.Services.AddInfrastructureDependancies();
            // Add Service Dependancies
            builder.Services.AddServiceDependancies();
            builder.Services.SrviceIdentityRegisturation(builder.Configuration);
            // Add Core Dependancies
            builder.Services.AddCoreDependancies();

            #endregion



            // Add Swagger UI for browser-based API testing
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Configure Localization
            builder.Services.AddControllersWithViews();
            builder.Services.AddLocalization(opt => { opt.ResourcesPath = string.Empty; });

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                List<CultureInfo> supportedCultures = new List<CultureInfo>
                                {
                                    new CultureInfo("en-US"),
                                    new CultureInfo("de-DE"),
                                    new CultureInfo("fr-FR"),
                                    new CultureInfo("en-GB"),
                                    new CultureInfo("ar-EG")
                                };
                options.DefaultRequestCulture = new RequestCulture("en-GB");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            #endregion


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();  // For OpenAPI endpoints
                app.UseSwagger();
                app.UseSwaggerUI();    //  ADD THIS for browser-based UI
            }
            #region Configure Localization
            ////it doesn't work
            //app.UseRequestLocalization(options =>
            //{
            //    var questStringCultureProvider = options.RequestCultureProviders[0];
            //    options.RequestCultureProviders.RemoveAt(0);
            //    options.RequestCultureProviders.Insert(1, questStringCultureProvider);
            //});

            var localizationOptions = app.Services.GetRequiredService<Microsoft.Extensions.Options.IOptions<RequestLocalizationOptions>>().Value;
            app.UseRequestLocalization(localizationOptions);

            #endregion




            app.UseHttpsRedirection();
            // Enable CORS
            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.MapControllers();

            ////Add a simple health check endpoint
            //app.MapGet("/", () => Results.Ok("School Management API is running."));

            app.Run();
        }
    }
}
