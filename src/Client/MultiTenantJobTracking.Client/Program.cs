using Microsoft.AspNetCore.Authentication.Cookies;
using MultiTenantJobTracking.Client.Services.Abstraction;
using MultiTenantJobTracking.Client.Services.Concrete;
using static MultiTenantJobTracking.Client.Services.Concrete.UserJobService;

namespace MultiTenantJobTracking.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new HttpResponseExceptionFilter());
            });
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddTransient<TokenHandler>();

            builder.Services.AddHttpClient("WebApiUrl", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiUrl"));
            })
            .AddHttpMessageHandler<TokenHandler>();

            builder.Services.AddScoped(sp =>
            {
                var clientFactory = sp.GetRequiredService<IHttpClientFactory>();
                return clientFactory.CreateClient("WebApiUrl");
            });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
             {
               options.LoginPath = "/User/Login"; // Kullanýcýnýn yönlendirileceði login sayfasý
              });
          
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ILicenceService, LicenceService>();
            
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IDepartmentUserService, DepartmentUserService>();
            
            builder.Services.AddScoped<ITenantService, TenantService>();
            builder.Services.AddScoped<ITenantUserService,TenantUserService>();
            
            builder.Services.AddScoped<IJobCommentService,JobCommentService>();
            builder.Services.AddScoped<IJobLogService,JobLogService>();
            builder.Services.AddScoped<IJobService,JobService>();
            builder.Services.AddScoped<IUserJobService, UserJobService>();
           
            builder.Services.AddScoped<IMessageService, MessageService>();

            var app = builder.Build();

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
