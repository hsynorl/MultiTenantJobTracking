using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using MultiTenantJobTracking.DataAccess.Configuration;
using MultiTenantJobTracking.DataAccess.Context;
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
                options.UseNpgsql(Configurations.ConnectionString);

            });
         

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);  // veri tabınında tarih formatını değiştirmek için 


            return services;

        }
    }
}
