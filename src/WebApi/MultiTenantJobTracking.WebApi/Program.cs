using Microsoft.OpenApi.Models;
using MultiTenantJobTracking.Business.Extentions;
using MultiTenantJobTracking.DataAccess.Extentions;
using MultiTenantJobTracking.WebApi.Extentions;
using MultiTenantJobTracking.WebApi.Middleware.ExcepitonHandling;
using MultiTenantJobTracking.WebApi.Services;
namespace MultiTenantJobTracking.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddBusinessService();
            builder.Services.AddDataAccessService(builder.Configuration);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddScoped<UserHelper>();
            builder.Services.AddHttpContextAccessor();

            builder.Services.ConfigureAuthentication(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.MapControllers();

            app.Run();
        }
    }
}
