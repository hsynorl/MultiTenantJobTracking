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
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MultiTenantJobTrackingDbContext>
    {
        private readonly IConfiguration configuration;

        public DesignTimeDbContextFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public MultiTenantJobTrackingDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<MultiTenantJobTrackingDbContext> dbContextOptionsBuilder = new();

            var connectionString = configuration.GetConnectionString("sqlServer");
            //TODO Değişecek.
            //string connectionString = "Server=sql-server;Database=MultiTenantJobTrackingDb;User Id=sa;Password=targe*+1507!.QpAiSwRdQdv;TrustServerCertificate=True;";
            dbContextOptionsBuilder.UseSqlServer(connectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
