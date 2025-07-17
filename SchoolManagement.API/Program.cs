
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Infrastructure;
using SchoolManagement.Infrastructure.Data;
namespace SchoolManagement.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
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

            // Add infrastructure dependencies
            builder.Services.AddInfrastructureDependancies();

            // Add Swagger UI for browser-based API testing
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();  // For OpenAPI endpoints
                app.UseSwagger();
                app.UseSwaggerUI();    //  ADD THIS for browser-based UI
            }


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            // Add a simple health check endpoint
            app.MapGet("/", () => Results.Ok("School Management API is running."));
            
            app.Run();
        }
    }
}
