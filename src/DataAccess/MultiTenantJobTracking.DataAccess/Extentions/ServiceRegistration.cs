using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiTenantJobTracking.DataAccess.Configuration;
using MultiTenantJobTracking.DataAccess.Context;
using MultiTenantJobTracking.DataAccess.Repositories.Abstract;
using MultiTenantJobTracking.DataAccess.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.DataAccess.Extentions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddDataAccessService(this IServiceCollection services)
        {

            services.AddDbContext<MultiTenantJobTrackingDbContext>(options =>
            {
                options.UseSqlServer(Configurations.ConnectionString);

            });
         
            services.AddScoped<ITenantRepository,TenantRepository>();   
            services.AddScoped<ITenantUserRepository,TenantUserRepository>();   
            services.AddScoped<IUserRepository,UserRepository>();   
            services.AddScoped<IUserJobRepository,UserJobRepository>();   
            services.AddScoped<IDepartmentAdminRepository,DepartmentAdminRepository>();   
            services.AddScoped<IDepartmentUserRepository,DepartmentUserRepository>();   
            services.AddScoped<IDepartmentRepository,DepartmentRepository>();   
            services.AddScoped<ILicenceRepository,LicenceRepository>();   
            services.AddScoped<IJobCommentRepository,JobCommentRepository>();   
            services.AddScoped<IJobLogRepository,JobLogRepository>();   
            services.AddScoped<IJobRepository,JobRepository>();   



            return services;

        }
    }
}
