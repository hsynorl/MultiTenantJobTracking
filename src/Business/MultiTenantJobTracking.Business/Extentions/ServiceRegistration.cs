using Microsoft.Extensions.DependencyInjection;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Business.Services.Concrete;
using MultiTenantJobTracking.DataAccess.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Business.Extentions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {
            services.AddScoped<ITenantService, TenantService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IDepartmentUserService, DepartmentUserService>();
            services.AddScoped<IDepartmentAdminService, DepartmentAdminService>();
            services.AddScoped<IJobLogService, JobLogService>();
            services.AddScoped<IJobCommentService, JobCommentService>();
            services.AddDataAccessService();
            return services;
        }
    }
}
