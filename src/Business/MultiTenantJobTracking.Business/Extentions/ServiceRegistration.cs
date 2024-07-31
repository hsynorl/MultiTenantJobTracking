using Microsoft.Extensions.DependencyInjection;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Business.Services.Concrete;
using MultiTenantJobTracking.DataAccess.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace MultiTenantJobTracking.Business.Extentions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {

            var assm = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assm);


            services.AddScoped<IDepartmentAdminService, DepartmentAdminService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IDepartmentUserService, DepartmentUserService>();
            services.AddScoped<IJobCommentService, JobCommentService>();
            services.AddScoped<IJobLogService, JobLogService>();
            services.AddScoped<IJobService,JobService>();
            services.AddScoped<ITenantService, TenantService>();
            services.AddScoped<ITenantUserService,TenantUserService>();
            services.AddScoped<ILicenceService,LicenceService>();
            services.AddScoped<IUserJobService,UserJobService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
