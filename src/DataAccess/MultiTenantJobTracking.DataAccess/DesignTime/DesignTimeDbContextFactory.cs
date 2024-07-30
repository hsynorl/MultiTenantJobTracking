using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenantJobTracking.DataAccess.Context;

namespace MultiTenantJobTracking.DataAccess.DesignTime
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MultiTenantJobTrackingDbContext>
    {
        public MultiTenantJobTrackingDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<MultiTenantJobTrackingDbContext> dbContextOptionsBuilder = new();

            //TODO Değişecek.

            string connectionString = "User ID=postgres;Password=targe*+1507!.QpAiSwRdQdv;Host=localhost;Port=5432; Database=MultiTenantJobTracking;";
            dbContextOptionsBuilder.UseNpgsql(connectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
