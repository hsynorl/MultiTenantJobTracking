using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenantJobTracking.DataAccess.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MultiTenantJobTracking.DataAccess.Configuration;

namespace MultiTenantJobTracking.DataAccess.DesignTime
{
    //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MultiTenantJobTrackingDbContext>
    //{
    //    public MultiTenantJobTrackingDbContext CreateDbContext(string[] args)
    //    {
    //        DbContextOptionsBuilder<MultiTenantJobTrackingDbContext> dbContextOptionsBuilder = new();

    //        dbContextOptionsBuilder.UseSqlServer(Configurations.ConnectionString);
    //        return new(dbContextOptionsBuilder.Options);
    //    }
    //}
}
