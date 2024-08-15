using Microsoft.AspNetCore.Authentication.Cookies;
using MultiTenantJobTracking.Client.Services.Abstraction;
using MultiTenantJobTracking.Client.Services.Concrete;

namespace MultiTenantJobTracking.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
           .AddCookie(options =>
           {
               options.LoginPath = "/Account/Login"; // Kullanýcýnýn yönlendirileceði login sayfasý
           });

            builder.Services.AddHttpClient("WebApiClient", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiUrl"));
            });


            builder.Services.AddScoped(sp =>
            {
                var clientFactory = sp.GetRequiredService<IHttpClientFactory>();
                return clientFactory.CreateClient("WebApiClient");
            });

            builder.Services.AddScoped<IUserService, UserService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
