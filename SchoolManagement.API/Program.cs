
using Microsoft.EntityFrameworkCore;
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
                options.UseSqlServer(builder.Configuration.GetConnectionString("local")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
